using Models;

namespace Garden.Tests
{
    public class ModelMock
    {
        /*          インメモリではないときの記述。非同期メソッドに対しては利用できない。
         *          public static Mock<DbSet<Models.Garden>> SetGardenDataSetMock(){
                    // Arrange
                    var gardens = new List<Models.Garden>
                    {
                        new Models.Garden
                        {
                            GardenId = 1,
                            Name = "TestGarden",
                            Location = "Location1",
                            Size = 100,
                            ImagePath = "/images/garden1.jpg",
                            IsManagementEnded = false,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            UserId = 1,
                            User = new User { UserId = 1, UserName = "TestUser", Email = "test@example.com", PasswordHash = "AAA", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                        },
                        new Models.Garden
                        {
                            GardenId = 1,
                            Name = "MasterGarden",
                            Location = "Location1",
                            Size = 100,
                            ImagePath = null,
                            IsManagementEnded = true,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            UserId = 1,
                            User = new User { UserId = 1, UserName = "TestUser", Email = "test@example.com", PasswordHash = "AAA", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                        },
                    }.AsQueryable();

                    *//*
                    Moq ライブラリを使って DbSet<Models.Garden> のモックオブジェクトを作成しています。
                    DbSet<Models.Garden> は、EF Core が Garden エンティティに対応するデータベースのテーブルを表すオブジェクトです。
                    *//*
                    var mockDbSet = new Mock<DbSet<Models.Garden>>();
                    *//*
                     * モックオブジェクトの Provider プロパティが、gardens.Provider と同じものを返すように設定しています。
                     * Provider は LINQ クエリを実行するための情報を提供するもので、モックされた DbSet がこのクエリプロバイダーを使用して動作するようにします。
                     *//*
                    mockDbSet.As<IQueryable<Models.Garden>>().Setup(m => m.Provider).Returns(gardens.Provider);
                    *//* Expression プロパティは、クエリの式ツリーを表します。モックオブジェクトが実際の IQueryable と同じクエリ式を持つように設定しています。 *//*
                    mockDbSet.As<IQueryable<Models.Garden>>().Setup(m => m.Expression).Returns(gardens.Expression);
                    *//* ElementType プロパティは、クエリが返す要素の型 (Garden 型) を示します。この行は、モックが DbSet<Models.Garden> と同じ型情報を提供することを保証しています。*//*
                    mockDbSet.As<IQueryable<Models.Garden>>().Setup(m => m.ElementType).Returns(gardens.ElementType);
                    *//*GetEnumerator() メソッドは、IQueryable クエリを列挙可能にするためのメソッドです。ここでは、モックされた DbSet が gardens クエリと同じ列挙子を返すように設定しています。*//*
                    mockDbSet.As<IQueryable<Models.Garden>>().Setup(m => m.GetEnumerator()).Returns(gardens.GetEnumerator());
                    *//*
                     _mockDbContext（HomeGardenContext のモック）が、Gardens プロパティとして mockDbSet.Object を返すように設定します。
                     これにより、GetGardensService クラスのテスト中に _dbContext.Gardens を呼び出すと、実際のデータベースにアクセスする代わりに、設定したモックオブジェクトを使用するようになります。
                     *//*
                    return mockDbSet;
                }*/

        public static void SetSeedTestData(HomeGardenContext context)
        {
            context.Gardens.AddRange(new List<Models.Garden>
            {
                new Models.Garden
                {
                    GardenId = 1,
                    Name = "TestGarden",
                    Location = "Location1",
                    Size = 100,
                    IsManagementEnded = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = 1,
                    User = new User { UserId = 1, UserName = "TestUser", Email = "test@example.com", PasswordHash = "AAA", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                },
                new Models.Garden
                {
                    GardenId = 2,
                    Name = "MasterGarden",
                    Location = "Location2",
                    Size = 200,
                    IsManagementEnded = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = 2,
                    User = new User { UserId = 2, UserName = "MasterUser", Email = "master@example.com", PasswordHash = "BBB", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                },
            });

            context.SaveChanges();
        }

    }
}
