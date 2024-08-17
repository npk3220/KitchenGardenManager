using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class Seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlantMasters",
                columns: new[] { "PlantMasterId", "CreatedAt", "Description", "ImagePath", "OptimalConditions", "PlantFamily", "PlantName", "ScientificName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9855), "A red fruit commonly used in cooking.", null, "Full sun, moderate watering", "Solanaceae", "Tomato", "Solanum lycopersicum", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9856) },
                    { 2, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9857), "An orange root vegetable.", null, "Full sun, well-drained soil", "Apiaceae", "Carrot", "Daucus carota", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9858) }
                });

            migrationBuilder.InsertData(
                table: "PlantStatusMasters",
                columns: new[] { "PlantStatusMasterId", "CreatedAt", "Description", "StatusName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9919), "The plant has been planted.", "plant", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9920) },
                    { 2, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9921), "The plant has sprouted.", "sprouting", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9922) },
                    { 3, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9923), "The plant has been harvested.", "harvest", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9923) },
                    { 4, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9924), "The plant is blooming.", "blooming", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9924) },
                    { 5, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9925), "The plant has withered.", "withering", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9925) },
                    { 6, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9926), "Fertilization has been applied.", "fertilization", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9927) },
                    { 7, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9928), "The plant is affected by pests or diseases.", "pest", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9928) },
                    { 8, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9929), "The plant has been removed.", "remove", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9929) },
                    { 9, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9930), "Other status not specified.", "other", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9931) }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "CreatedAt", "Name", "PlantMasterId", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9887), "Tomato", 1, 10, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9888) },
                    { 2, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9889), "Mystery Plant", null, 5, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9889) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "ImagePath", "PasswordHash", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9702), "admin@example.com", null, "hashed_password_123", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9719), "admin" },
                    { 2, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9721), "user1@example.com", null, "hashed_password_456", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9721), "user1" }
                });

            migrationBuilder.InsertData(
                table: "Gardens",
                columns: new[] { "GardenId", "CreatedAt", "ImagePath", "IsManagementEnded", "Location", "Name", "Size", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9821), null, false, "Backyard", "Main Garden", 100.5, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9822), 1 },
                    { 2, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9823), null, false, "Front Yard", "Front Yard Garden", 50.0, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9824), 1 }
                });

            migrationBuilder.InsertData(
                table: "PlantHistories",
                columns: new[] { "PlantHistoryId", "CreatedAt", "EventDate", "ImagePath", "Notes", "PlantId", "PlantStatusId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 16, 17, 11, 24, 111, DateTimeKind.Local).AddTicks(15), new DateTime(2024, 7, 17, 17, 11, 24, 111, DateTimeKind.Local).AddTicks(14), null, null, 1, 1, new DateTime(2024, 8, 16, 17, 11, 24, 111, DateTimeKind.Local).AddTicks(15) },
                    { 2, new DateTime(2024, 8, 16, 17, 11, 24, 111, DateTimeKind.Local).AddTicks(17), new DateTime(2024, 8, 11, 17, 11, 24, 111, DateTimeKind.Local).AddTicks(16), null, null, 1, 2, new DateTime(2024, 8, 16, 17, 11, 24, 111, DateTimeKind.Local).AddTicks(17) },
                    { 3, new DateTime(2024, 8, 16, 17, 11, 24, 111, DateTimeKind.Local).AddTicks(19), new DateTime(2024, 7, 27, 17, 11, 24, 111, DateTimeKind.Local).AddTicks(19), null, null, 2, 1, new DateTime(2024, 8, 16, 17, 11, 24, 111, DateTimeKind.Local).AddTicks(20) }
                });

            migrationBuilder.InsertData(
                table: "GardenHistories",
                columns: new[] { "GardenHistoryId", "ActionDate", "ActionType", "CreatedAt", "Details", "GardenId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 6, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9960), "Fertilization", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9964), "Added compost", 1, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9964) },
                    { 2, new DateTime(2024, 8, 11, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9966), "Measurement", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9966), "Soil pH measured", 1, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9967) },
                    { 3, new DateTime(2024, 8, 6, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9968), "Fertilization", new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9969), "Added compost", 2, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9969) }
                });

            migrationBuilder.InsertData(
                table: "GardenPlantRelations",
                columns: new[] { "GardenPlantRelationId", "CreatedAt", "GardenId", "PlantId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9991), 1, 1, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9992) },
                    { 2, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9993), 1, 2, new DateTime(2024, 8, 16, 17, 11, 24, 110, DateTimeKind.Local).AddTicks(9994) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GardenHistories",
                keyColumn: "GardenHistoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GardenHistories",
                keyColumn: "GardenHistoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GardenHistories",
                keyColumn: "GardenHistoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GardenPlantRelations",
                keyColumn: "GardenPlantRelationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GardenPlantRelations",
                keyColumn: "GardenPlantRelationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlantHistories",
                keyColumn: "PlantHistoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlantHistories",
                keyColumn: "PlantHistoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlantHistories",
                keyColumn: "PlantHistoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlantMasters",
                keyColumn: "PlantMasterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlantMasters",
                keyColumn: "PlantMasterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlantStatusMasters",
                keyColumn: "PlantStatusMasterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlantStatusMasters",
                keyColumn: "PlantStatusMasterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlantStatusMasters",
                keyColumn: "PlantStatusMasterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PlantStatusMasters",
                keyColumn: "PlantStatusMasterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PlantStatusMasters",
                keyColumn: "PlantStatusMasterId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PlantStatusMasters",
                keyColumn: "PlantStatusMasterId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PlantStatusMasters",
                keyColumn: "PlantStatusMasterId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gardens",
                keyColumn: "GardenId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gardens",
                keyColumn: "GardenId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlantStatusMasters",
                keyColumn: "PlantStatusMasterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlantStatusMasters",
                keyColumn: "PlantStatusMasterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
