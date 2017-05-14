﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Download;
using Google.Apis.Drive.v2.Data;
using System.IO;
using Windows.Storage;
using System.Threading;
using Windows.Storage.Streams;

namespace GoogleDriveForApp.GoogleDriveForApp
{
    class GoogleDriveServiceForApp
    {
        private readonly string[] _scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private DriveService _service;
        private const int KB = 0x400;
        private const int DOWNLOAD_CHUNK_SIZE = 256 * KB;
        private int _timeStamp;
        private string _applicationName;
        private string _clientSecretFileName;
        private UserCredential _credential;
        const int DOUBLE = 2;
        const string SEGMENT = "ms-appx:///Assets/";

        public GoogleDriveServiceForApp(string applicationName, string clientSecretFileName)//創造一個Google Drive Service
        {
            _applicationName = applicationName;
            _clientSecretFileName = clientSecretFileName;
            this.CreateNewService(applicationName, clientSecretFileName);
        }

        private async void CreateNewService(string applicationName, string clientSecretFileName)//CreateNewService
        {
            const string USER = "user";
            string credentialURI = SEGMENT + clientSecretFileName;
            UserCredential credential = null;
            Uri credentialFileUri = new Uri(credentialURI);
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(credentialFileUri, new[] { Uri.EscapeUriString(DriveService.Scope.Drive) }, USER, CancellationToken.None);
            DriveService service = new DriveService(new BaseClientService.Initializer() 
            { HttpClientInitializer = credential, ApplicationName = applicationName });
            _credential = credential;
            DateTime now = DateTime.Now;
            _timeStamp = UNIXNowTimeStamp;
            _service = service;
        }

        private int UNIXNowTimeStamp//設定時間
        {
            get
            {
                const int UNIX_START_YEAR = 1970;
                DateTime unixStartTime = new DateTime(UNIX_START_YEAR, 1, 1);
                return Convert.ToInt32((DateTime.Now.Subtract(unixStartTime).TotalSeconds));
            }
        }

        private void CheckCredentialTimeStamp()//Check and refresh the credential if credential is out-of-date
        {
            const int ONE_HOUR_SECOND = 3600;
            int nowTimeStamp = UNIXNowTimeStamp;

            if ((nowTimeStamp - _timeStamp) > ONE_HOUR_SECOND)
                this.CreateNewService(_applicationName, _clientSecretFileName);
        }

        public List<Google.Apis.Drive.v2.Data.File> ListRootFileAndFolder()//查詢Google Drive 根目錄的檔案
        {
            List<Google.Apis.Drive.v2.Data.File> returnList = new List<Google.Apis.Drive.v2.Data.File>();
            const string ROOT_QUERY_STRING = "'root' in parents";

            try
            {
                returnList = ListFileAndFolderWithQueryString(ROOT_QUERY_STRING);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return returnList;
        }

        private List<Google.Apis.Drive.v2.Data.File> ListFileAndFolderWithQueryString(string queryString)//使用QueryString 查詢檔案 回傳一List
        {
            List<Google.Apis.Drive.v2.Data.File> returnList;
            returnList = new List<Google.Apis.Drive.v2.Data.File>();
            this.CheckCredentialTimeStamp();
            FilesResource.ListRequest listRequest;
            listRequest = _service.Files.List();
            listRequest.Q = queryString;
            do
            {
                try
                {
                    FileList fileList;
                    fileList = listRequest.Execute();
                    returnList.AddRange(fileList.Items);
                    listRequest.PageToken = fileList.NextPageToken;
                }
                catch (Exception exception)
                {
                    listRequest.PageToken = null;
                    throw exception;
                }
            } while (!String.IsNullOrEmpty(listRequest.PageToken));
            return returnList;
        }

        public async Task<Google.Apis.Drive.v2.Data.File> UploadFile(string uploadFileName, string contentType, Action<IUploadProgress> uploadProgressEventHandler = null, Action<Google.Apis.Drive.v2.Data.File> responseReceivedEventHandler = null)//上傳檔案
        {
            Windows.Storage.StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync(uploadFileName);
            IRandomAccessStream readStream = await file.OpenReadAsync();
            Stream uploadStream = readStream.AsStream();
            string title = uploadFileName;
            this.CheckCredentialTimeStamp();
            Google.Apis.Drive.v2.Data.File fileToInsert = new Google.Apis.Drive.v2.Data.File 
            {Title = title};
            FilesResource.InsertMediaUpload insertRequest = _service.Files.Insert(fileToInsert, uploadStream, contentType);
            insertRequest.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize * DOUBLE;
            AddUploadEventHandler(uploadProgressEventHandler, responseReceivedEventHandler, insertRequest);
            try
            {
                insertRequest.Upload();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                uploadStream.Dispose();
            }
            return insertRequest.ResponseBody;
        }

        private static void AddUploadEventHandler(Action<IUploadProgress> uploadProgressEventHandler, Action<Google.Apis.Drive.v2.Data.File> responseReceivedEventHandler, FilesResource.InsertMediaUpload insertRequest)//Add Upload Event Handler
        {
            if (uploadProgressEventHandler != null)
                insertRequest.ProgressChanged += uploadProgressEventHandler;

            if (responseReceivedEventHandler != null)
                insertRequest.ResponseReceived += responseReceivedEventHandler;
        }

        private static string SubtractFileName(string uploadFileName)//如檔案名稱帶有路徑，將路徑去除，回傳檔案名稱
        {
            const char SPLASH = '\\';
            string title = "";

            if (uploadFileName.LastIndexOf(SPLASH) != -1)
                title = uploadFileName.Substring(uploadFileName.LastIndexOf(SPLASH) + 1);
            else
                title = uploadFileName;
            return title;
        }

        public async void DownloadFile(Google.Apis.Drive.v2.Data.File fileToDownload, Action<IDownloadProgress> downloadProgressChangedEventHandler = null)//下載檔案
        {
            CheckCredentialTimeStamp();
            if (!String.IsNullOrEmpty(fileToDownload.DownloadUrl))
            {
                
                try
                {
                    StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileToDownload.Title, CreationCollisionOption.ReplaceExisting);
                    Task<byte[]> downloadByte = _service.HttpClient.GetByteArrayAsync(fileToDownload.DownloadUrl);
                    byte[] byteArray = downloadByte.Result;
                    await FileIO.WriteBytesAsync(file, byteArray);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }

        public void DeleteFile(string fileId)//刪除符合FileID的檔案
        {
            CheckCredentialTimeStamp();
            try
            {
                _service.Files.Delete(fileId).Execute();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Google.Apis.Drive.v2.Data.File> UpdateFile(string fileName, string fileId, string contentType)//更新指定FileID的檔案
        {
            CheckCredentialTimeStamp();
            try
            {
                Google.Apis.Drive.v2.Data.File file = _service.Files.Get(fileId).Execute();
                StorageFile fileToUpdate = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                IRandomAccessStream randomAccessStream = await fileToUpdate.OpenReadAsync();
                Stream stream = randomAccessStream.AsStream();
                FilesResource.UpdateMediaUpload request = _service.Files.Update(file, fileId, stream, contentType);
                request.NewRevision = true;
                request.Upload();
                Google.Apis.Drive.v2.Data.File updatedFile = request.ResponseBody;
                return updatedFile;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

