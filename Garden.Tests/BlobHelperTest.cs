using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;


namespace Garden.Tests
{
    public class BlobHelperTests
    {
        [Fact]
        public async Task UploadBlobAsync_ShouldThrowRequestFailedException_WhenForbidden()
        {
            // Arrange
            var blobClientMock = new Mock<BlobClient>();
            var stream = new MemoryStream();

            // 403エラーを発生させるように設定
            blobClientMock
                .Setup(x => x.UploadAsync(It.IsAny<Stream>(), true, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new RequestFailedException(403, "Access forbidden"));

            var blobHelper = new BlobHelper(blobClientMock.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<RequestFailedException>(() => blobHelper.UploadBlobAsync(stream));

            // 例外のステータスコードが403であることを確認
            Assert.Equal(403, exception.Status);
            Assert.Equal("Access forbidden", exception.Message);
        }

        [Fact]
        public async Task UploadBlobAsync_ShouldThrowRequestFailedException_WhenOtherErrorOccurs()
        {
            // Arrange
            var blobClientMock = new Mock<BlobClient>();
            var stream = new MemoryStream();

            // 任意のその他のエラー（例えば500）を発生させるように設定
            blobClientMock
                .Setup(x => x.UploadAsync(It.IsAny<Stream>(), true, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new RequestFailedException(500, "Internal server error"));

            var blobHelper = new BlobHelper(blobClientMock.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<RequestFailedException>(() => blobHelper.UploadBlobAsync(stream));

            // 例外のステータスコードが500であることを確認
            Assert.Equal(500, exception.Status);
            Assert.Equal("Internal server error", exception.Message);
        }

        [Fact]
        public async Task UploadBlobAsync_ShouldUploadSuccessfully_WhenNoErrorOccurs()
        {
            // Arrange
            var blobClientMock = new Mock<BlobClient>();
            var stream = new MemoryStream();

            // エラーが発生しない設定
            blobClientMock
                .Setup(x => x.UploadAsync(It.IsAny<Stream>(), true, It.IsAny<CancellationToken>()))
                .ReturnsAsync(Mock.Of<Response<BlobContentInfo>>());

            var blobHelper = new BlobHelper(blobClientMock.Object);

            // Act
            await blobHelper.UploadBlobAsync(stream);

            // Assert
            blobClientMock.Verify(x => x.UploadAsync(It.IsAny<Stream>(), true, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
