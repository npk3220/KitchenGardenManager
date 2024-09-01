using Azure;
using Azure.Identity;
using Azure.Storage.Blobs;

namespace Garden
{
    public class BlobHelper
    {
        private readonly BlobClient _blobClient;

        public BlobHelper(BlobClient blobClient)
        {
            _blobClient = blobClient;
        }

        public async Task UploadBlobAsync(Stream data)
        {
            try
            {
                await _blobClient.UploadAsync(data, true);
            }
            catch (RequestFailedException ex) when (ex.Status == 403)
            {
                // 403エラー時の処理
                Console.WriteLine($"Access forbidden: {ex.Message}");
                // 必要に応じて再試行やエラーログの記録を行う
                throw;
            }
            catch (RequestFailedException ex)
            {
                // その他のエラー
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
