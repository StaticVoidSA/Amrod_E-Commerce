using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Amrod_E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class Seed100Rows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageURL", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("037f6a2d-bd1f-4968-abd6-e2951ca64ac8"), "Description for Product 15", "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80", "Product 15", 697.07m, 60 },
                    { new Guid("04d9242a-22a8-4ac6-851b-2abb29e6ce44"), "Description for Product 52", "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80", "Product 52", 133.40m, 83 },
                    { new Guid("09095c62-7b60-4a27-a13b-870f4b68608d"), "Description for Product 13", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80", "Product 13", 10.42m, 57 },
                    { new Guid("092e3e57-9ceb-448c-95cc-ef10dfb54586"), "Description for Product 62", "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80", "Product 62", 572.54m, 29 },
                    { new Guid("184532c7-350e-4074-b0b4-f2ff46a5746e"), "Description for Product 82", "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80", "Product 82", 937.61m, 77 },
                    { new Guid("18ccfe7f-6721-4b53-bb8e-de2b00b6380b"), "Description for Product 77", "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80", "Product 77", 843.06m, 78 },
                    { new Guid("1996ee07-cdeb-4aa5-b2b9-8a549a9a5652"), "Description for Product 18", "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80", "Product 18", 778.49m, 95 },
                    { new Guid("1c770d86-38da-4444-95c2-0e502a79ca91"), "Description for Product 2", "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80", "Product 2", 674.23m, 84 },
                    { new Guid("2a78bef0-67c6-4719-aaba-85a34e6453f4"), "Description for Product 34", "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80", "Product 34", 663.99m, 72 },
                    { new Guid("2b894b48-a9b7-42e8-97ce-3dc5c938118a"), "Description for Product 96", "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80", "Product 96", 102.70m, 90 },
                    { new Guid("2d215943-f0d5-47f6-8d77-2acac457df25"), "Description for Product 21", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80", "Product 21", 854.15m, 95 },
                    { new Guid("2d7592f1-7dfe-41e3-bfbb-ca88a672355b"), "Description for Product 76", "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80", "Product 76", 578.35m, 50 },
                    { new Guid("30e7a280-f400-428f-9f29-5765d300b697"), "Description for Product 89", "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80", "Product 89", 910.28m, 25 },
                    { new Guid("352c05dc-841b-47a9-a4ec-ec64cf91d543"), "Description for Product 35", "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80", "Product 35", 61.82m, 36 },
                    { new Guid("36f8e3b4-d75e-4d07-9e29-88ea9a7cd289"), "Description for Product 42", "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80", "Product 42", 137.14m, 31 },
                    { new Guid("3dafb01c-8140-4365-85c8-5774f54e0e7a"), "Description for Product 64", "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80", "Product 64", 157.59m, 2 },
                    { new Guid("3de66135-ddd4-43f8-92e1-7178bf1f3822"), "Description for Product 30", "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80", "Product 30", 627.24m, 68 },
                    { new Guid("40ca4120-28b5-4a21-a9d3-955d592ace98"), "Description for Product 17", "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80", "Product 17", 167.14m, 79 },
                    { new Guid("40cc1aaf-ae8c-48e6-9edc-14a1ba06514c"), "Description for Product 8", "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80", "Product 8", 788.33m, 3 },
                    { new Guid("40e457aa-4fe5-4475-bd31-b57886078624"), "Description for Product 45", "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80", "Product 45", 62.84m, 57 },
                    { new Guid("41342dde-bb7b-40a2-84ff-9d2e10e8adb6"), "Description for Product 92", "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80", "Product 92", 919.09m, 35 },
                    { new Guid("45c4c150-f114-4dba-8bd4-a8e02d1c74a7"), "Description for Product 79", "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80", "Product 79", 46.14m, 1 },
                    { new Guid("461fa09e-d107-4301-8f72-fc0dfaedb919"), "Description for Product 55", "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80", "Product 55", 564.67m, 13 },
                    { new Guid("4f25dcd4-a3b1-43ed-9c4a-d9b505696b2a"), "Description for Product 40", "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80", "Product 40", 304.11m, 25 },
                    { new Guid("5128da86-295a-4423-b450-2a412a3442de"), "Description for Product 80", "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80", "Product 80", 523.47m, 50 },
                    { new Guid("551dbfe4-c891-43ff-b453-c429839a46dd"), "Description for Product 50", "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80", "Product 50", 725.94m, 73 },
                    { new Guid("559a05ec-aa7e-4330-948c-9cdba49638c6"), "Description for Product 73", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80", "Product 73", 233.71m, 72 },
                    { new Guid("570eddb7-a3a9-419c-b21a-23e9306d5005"), "Description for Product 33", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80", "Product 33", 580.34m, 98 },
                    { new Guid("5dbd5b81-f732-4c54-b06d-bba178f31704"), "Description for Product 84", "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80", "Product 84", 557.89m, 40 },
                    { new Guid("5ed40460-aa92-4a3e-8ef5-2ba8d2321a11"), "Description for Product 14", "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80", "Product 14", 913.99m, 44 },
                    { new Guid("5ff705b7-ec20-475f-b7c6-2168e02b206b"), "Description for Product 29", "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80", "Product 29", 775.70m, 94 },
                    { new Guid("6345a15f-76b6-44ba-a85e-14509a760ced"), "Description for Product 44", "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80", "Product 44", 424.53m, 6 },
                    { new Guid("655e9743-2592-4505-8c2a-a3dce31285c9"), "Description for Product 7", "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80", "Product 7", 91.20m, 89 },
                    { new Guid("66284aab-7a0a-44b0-965e-1b884d3f50a8"), "Description for Product 26", "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80", "Product 26", 68.48m, 32 },
                    { new Guid("677d2f43-f14c-42c7-845e-0124e6a154b3"), "Description for Product 38", "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80", "Product 38", 345.42m, 47 },
                    { new Guid("685c330e-bba0-483a-a569-2e0b367e2dcb"), "Description for Product 3", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80", "Product 3", 37.57m, 49 },
                    { new Guid("688c93d3-5871-44ee-be3a-8e32438ac271"), "Description for Product 5", "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80", "Product 5", 558.80m, 45 },
                    { new Guid("68c00525-5204-4b1c-bcf8-353cf7711493"), "Description for Product 46", "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80", "Product 46", 570.63m, 28 },
                    { new Guid("6ab13456-89f6-4bc9-b919-22809acdcf51"), "Description for Product 28", "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80", "Product 28", 766.65m, 56 },
                    { new Guid("6acc26b5-a0fb-4d68-885c-8d47e4173fd7"), "Description for Product 53", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80", "Product 53", 151.75m, 35 },
                    { new Guid("6d0a3e92-0bcb-4e6f-a5a8-9cb8b9e221a6"), "Description for Product 54", "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80", "Product 54", 328.89m, 96 },
                    { new Guid("6d40207e-8359-4b04-8106-ef77695ea80a"), "Description for Product 72", "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80", "Product 72", 797.06m, 37 },
                    { new Guid("6e05e78a-dd41-4198-84eb-f700fa196a95"), "Description for Product 47", "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80", "Product 47", 560.87m, 68 },
                    { new Guid("6ef463c3-2015-4690-bc94-94398d256630"), "Description for Product 78", "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80", "Product 78", 635.03m, 54 },
                    { new Guid("7570839b-a79a-4564-97fc-23bfbfc75aca"), "Description for Product 97", "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80", "Product 97", 405.96m, 86 },
                    { new Guid("786abf70-08cf-474c-a6a4-77fcb1780836"), "Description for Product 4", "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80", "Product 4", 984.19m, 75 },
                    { new Guid("79a31bf0-e195-4dc9-bc47-7bf586962a6e"), "Description for Product 58", "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80", "Product 58", 801.76m, 80 },
                    { new Guid("822774f9-5c32-4384-bcef-e56351967140"), "Description for Product 99", "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80", "Product 99", 614.15m, 8 },
                    { new Guid("853436e5-a858-44c5-bba5-e24f1c5b9152"), "Description for Product 49", "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80", "Product 49", 300.00m, 32 },
                    { new Guid("856b34d0-8b9b-4fa9-bd56-7cf03f54f898"), "Description for Product 68", "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80", "Product 68", 874.58m, 13 },
                    { new Guid("89f2391b-03aa-42b8-b723-f586dc3501f0"), "Description for Product 66", "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80", "Product 66", 294.06m, 50 },
                    { new Guid("8b642753-c5bf-4142-836b-da5bf6678f8f"), "Description for Product 24", "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80", "Product 24", 652.94m, 60 },
                    { new Guid("8b8b7c92-8362-4c6f-be2e-ff6cb5deaf8b"), "Description for Product 51", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80", "Product 51", 710.47m, 98 },
                    { new Guid("8caf49f4-527d-423a-aca0-6d1d9755912b"), "Description for Product 100", "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80", "Product 100", 428.20m, 77 },
                    { new Guid("95261416-7181-4efe-a0e0-2bb73c6e60f0"), "Description for Product 23", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80", "Product 23", 999.48m, 65 },
                    { new Guid("97e4b534-778d-4eca-93f7-2b9ed88408fa"), "Description for Product 95", "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80", "Product 95", 962.42m, 16 },
                    { new Guid("97e6095d-b62d-4127-b580-612231d84c9f"), "Description for Product 16", "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80", "Product 16", 82.62m, 80 },
                    { new Guid("99b798e1-a536-4068-8215-8c1095dd0c65"), "Description for Product 87", "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80", "Product 87", 401.51m, 10 },
                    { new Guid("9a167db1-9cb0-49d3-b50e-a9104c282d7f"), "Description for Product 6", "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80", "Product 6", 836.26m, 83 },
                    { new Guid("9e61a62b-067b-4718-a03f-21508b4da9cb"), "Description for Product 81", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80", "Product 81", 828.41m, 42 },
                    { new Guid("a02c967b-9f90-4812-b2f4-4d9f6d2d1d45"), "Description for Product 36", "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80", "Product 36", 218.64m, 15 },
                    { new Guid("a0511ffe-5a09-499a-99bb-df4a9086c8cf"), "Description for Product 41", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80", "Product 41", 742.38m, 30 },
                    { new Guid("a177697b-bc85-42dc-a241-930758e71532"), "Description for Product 71", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80", "Product 71", 749.54m, 23 },
                    { new Guid("a4fa6c83-22ba-4912-a5bc-0306c594995e"), "Description for Product 90", "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80", "Product 90", 198.09m, 92 },
                    { new Guid("a539612d-8a1b-4c41-b75e-95b9fc1fa704"), "Description for Product 1", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80", "Product 1", 509.76m, 50 },
                    { new Guid("a87ac403-00bf-4dcb-a2d5-d6bb9c5f9460"), "Description for Product 11", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80", "Product 11", 214.84m, 92 },
                    { new Guid("ab9d2dc8-6ded-4518-aab4-7e5b617fd24d"), "Description for Product 48", "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80", "Product 48", 625.84m, 60 },
                    { new Guid("ac006d5d-21ca-4da2-8f50-3ced0523bc9e"), "Description for Product 9", "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80", "Product 9", 452.35m, 80 },
                    { new Guid("ada894d2-baca-4d14-9cca-7fabad3f0064"), "Description for Product 20", "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80", "Product 20", 700.44m, 91 },
                    { new Guid("ae51f95a-b4c3-4bc8-9ed9-8c238c176502"), "Description for Product 74", "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80", "Product 74", 780.02m, 33 },
                    { new Guid("ae6bd903-fa60-48c0-9d63-ee818bb19f45"), "Description for Product 56", "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80", "Product 56", 565.96m, 94 },
                    { new Guid("af439fa4-d207-4bfb-8f58-3a9b15ddbf4e"), "Description for Product 32", "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80", "Product 32", 519.79m, 61 },
                    { new Guid("af8149ca-ad63-4c98-8ab7-158e7b37459c"), "Description for Product 98", "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80", "Product 98", 905.38m, 23 },
                    { new Guid("b0a3e29f-a2e2-4665-af2e-7a3ed35e1111"), "Description for Product 43", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80", "Product 43", 762.30m, 31 },
                    { new Guid("b24f420d-9fd7-4fdb-b7cd-af9b50e1b22f"), "Description for Product 57", "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80", "Product 57", 496.29m, 48 },
                    { new Guid("b75f4970-2ba3-42a4-8092-b349a25d9b65"), "Description for Product 61", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80", "Product 61", 518.19m, 17 },
                    { new Guid("bce0b0f3-e0e6-4f87-b1a2-e2d2b9b8813a"), "Description for Product 88", "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80", "Product 88", 549.93m, 64 },
                    { new Guid("c37ac9ed-5fa2-484b-ad54-0e73b5b32365"), "Description for Product 37", "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80", "Product 37", 806.75m, 89 },
                    { new Guid("c4cd304c-1cee-472e-990b-c999944ca825"), "Description for Product 94", "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80", "Product 94", 13.79m, 99 },
                    { new Guid("c8353168-5a71-4247-9083-9217a3c5ead4"), "Description for Product 63", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80", "Product 63", 532.70m, 44 },
                    { new Guid("c9eeb650-f0a0-42f4-9618-cd2e4ecca6e5"), "Description for Product 93", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80", "Product 93", 138.95m, 15 },
                    { new Guid("caf07902-d1ac-4b72-bf66-60895193d296"), "Description for Product 86", "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80", "Product 86", 431.39m, 72 },
                    { new Guid("ce841829-e222-45d4-93b7-8c1158c4212e"), "Description for Product 75", "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80", "Product 75", 679.45m, 19 },
                    { new Guid("cec96b28-03d6-4297-8c80-3f9c030c1ec5"), "Description for Product 70", "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80", "Product 70", 199.81m, 25 },
                    { new Guid("cfa452b9-e571-48c2-ae62-00143475ae22"), "Description for Product 25", "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80", "Product 25", 673.13m, 10 },
                    { new Guid("d019b3ff-d9c6-4990-8744-ec338d8177f0"), "Description for Product 19", "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80", "Product 19", 897.20m, 63 },
                    { new Guid("d32f5e41-4926-4df0-858f-2efa1a9ce9fb"), "Description for Product 59", "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80", "Product 59", 742.99m, 62 },
                    { new Guid("d75d56a9-458e-4643-9f16-6a7b721aa0c7"), "Description for Product 83", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80", "Product 83", 809.86m, 38 },
                    { new Guid("d81713f9-95f9-4711-8215-0b012e7f32f8"), "Description for Product 85", "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80", "Product 85", 568.81m, 55 },
                    { new Guid("d9f919d1-4c86-4e13-b70a-8f8483e66cee"), "Description for Product 69", "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80", "Product 69", 691.41m, 80 },
                    { new Guid("da2935cb-dd92-49df-bbcc-116932ca60ce"), "Description for Product 39", "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80", "Product 39", 175.52m, 24 },
                    { new Guid("e3b13380-2756-4ac3-9fc3-db866421848e"), "Description for Product 22", "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80", "Product 22", 328.63m, 85 },
                    { new Guid("e63c8526-5f2d-40b0-a9ec-d43252f9df20"), "Description for Product 10", "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80", "Product 10", 386.78m, 90 },
                    { new Guid("e7564e36-8705-4072-91f0-cdd49ebdf291"), "Description for Product 12", "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80", "Product 12", 209.29m, 97 },
                    { new Guid("e8d3d2a6-2c5c-4be4-adec-bb8afc184ac7"), "Description for Product 27", "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80", "Product 27", 579.20m, 49 },
                    { new Guid("ebe8f767-538e-4b61-b820-aa10095cac9a"), "Description for Product 31", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80", "Product 31", 328.24m, 86 },
                    { new Guid("ec2b752a-64d5-4829-8d82-e1c70a1e2aab"), "Description for Product 67", "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80", "Product 67", 827.31m, 72 },
                    { new Guid("ede9bd29-e7da-4f85-af48-dfc4948faa55"), "Description for Product 65", "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80", "Product 65", 348.08m, 89 },
                    { new Guid("f5a9e094-5454-4750-bb27-54b8c8cde681"), "Description for Product 60", "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80", "Product 60", 660.27m, 54 },
                    { new Guid("fda97bf7-eb42-46a6-a7ea-a5102d3bdfd5"), "Description for Product 91", "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80", "Product 91", 943.11m, 42 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("037f6a2d-bd1f-4968-abd6-e2951ca64ac8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("04d9242a-22a8-4ac6-851b-2abb29e6ce44"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09095c62-7b60-4a27-a13b-870f4b68608d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("092e3e57-9ceb-448c-95cc-ef10dfb54586"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("184532c7-350e-4074-b0b4-f2ff46a5746e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("18ccfe7f-6721-4b53-bb8e-de2b00b6380b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1996ee07-cdeb-4aa5-b2b9-8a549a9a5652"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1c770d86-38da-4444-95c2-0e502a79ca91"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2a78bef0-67c6-4719-aaba-85a34e6453f4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2b894b48-a9b7-42e8-97ce-3dc5c938118a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d215943-f0d5-47f6-8d77-2acac457df25"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d7592f1-7dfe-41e3-bfbb-ca88a672355b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("30e7a280-f400-428f-9f29-5765d300b697"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("352c05dc-841b-47a9-a4ec-ec64cf91d543"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36f8e3b4-d75e-4d07-9e29-88ea9a7cd289"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3dafb01c-8140-4365-85c8-5774f54e0e7a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3de66135-ddd4-43f8-92e1-7178bf1f3822"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40ca4120-28b5-4a21-a9d3-955d592ace98"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40cc1aaf-ae8c-48e6-9edc-14a1ba06514c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40e457aa-4fe5-4475-bd31-b57886078624"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("41342dde-bb7b-40a2-84ff-9d2e10e8adb6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("45c4c150-f114-4dba-8bd4-a8e02d1c74a7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("461fa09e-d107-4301-8f72-fc0dfaedb919"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4f25dcd4-a3b1-43ed-9c4a-d9b505696b2a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5128da86-295a-4423-b450-2a412a3442de"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("551dbfe4-c891-43ff-b453-c429839a46dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("559a05ec-aa7e-4330-948c-9cdba49638c6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("570eddb7-a3a9-419c-b21a-23e9306d5005"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5dbd5b81-f732-4c54-b06d-bba178f31704"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5ed40460-aa92-4a3e-8ef5-2ba8d2321a11"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5ff705b7-ec20-475f-b7c6-2168e02b206b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6345a15f-76b6-44ba-a85e-14509a760ced"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("655e9743-2592-4505-8c2a-a3dce31285c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66284aab-7a0a-44b0-965e-1b884d3f50a8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("677d2f43-f14c-42c7-845e-0124e6a154b3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("685c330e-bba0-483a-a569-2e0b367e2dcb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("688c93d3-5871-44ee-be3a-8e32438ac271"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("68c00525-5204-4b1c-bcf8-353cf7711493"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6ab13456-89f6-4bc9-b919-22809acdcf51"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6acc26b5-a0fb-4d68-885c-8d47e4173fd7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d0a3e92-0bcb-4e6f-a5a8-9cb8b9e221a6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d40207e-8359-4b04-8106-ef77695ea80a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6e05e78a-dd41-4198-84eb-f700fa196a95"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6ef463c3-2015-4690-bc94-94398d256630"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7570839b-a79a-4564-97fc-23bfbfc75aca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("786abf70-08cf-474c-a6a4-77fcb1780836"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("79a31bf0-e195-4dc9-bc47-7bf586962a6e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("822774f9-5c32-4384-bcef-e56351967140"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("853436e5-a858-44c5-bba5-e24f1c5b9152"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("856b34d0-8b9b-4fa9-bd56-7cf03f54f898"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("89f2391b-03aa-42b8-b723-f586dc3501f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b642753-c5bf-4142-836b-da5bf6678f8f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b8b7c92-8362-4c6f-be2e-ff6cb5deaf8b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8caf49f4-527d-423a-aca0-6d1d9755912b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("95261416-7181-4efe-a0e0-2bb73c6e60f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("97e4b534-778d-4eca-93f7-2b9ed88408fa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("97e6095d-b62d-4127-b580-612231d84c9f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99b798e1-a536-4068-8215-8c1095dd0c65"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a167db1-9cb0-49d3-b50e-a9104c282d7f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9e61a62b-067b-4718-a03f-21508b4da9cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a02c967b-9f90-4812-b2f4-4d9f6d2d1d45"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0511ffe-5a09-499a-99bb-df4a9086c8cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a177697b-bc85-42dc-a241-930758e71532"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a4fa6c83-22ba-4912-a5bc-0306c594995e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a539612d-8a1b-4c41-b75e-95b9fc1fa704"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a87ac403-00bf-4dcb-a2d5-d6bb9c5f9460"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ab9d2dc8-6ded-4518-aab4-7e5b617fd24d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac006d5d-21ca-4da2-8f50-3ced0523bc9e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ada894d2-baca-4d14-9cca-7fabad3f0064"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ae51f95a-b4c3-4bc8-9ed9-8c238c176502"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ae6bd903-fa60-48c0-9d63-ee818bb19f45"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("af439fa4-d207-4bfb-8f58-3a9b15ddbf4e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("af8149ca-ad63-4c98-8ab7-158e7b37459c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0a3e29f-a2e2-4665-af2e-7a3ed35e1111"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b24f420d-9fd7-4fdb-b7cd-af9b50e1b22f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b75f4970-2ba3-42a4-8092-b349a25d9b65"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bce0b0f3-e0e6-4f87-b1a2-e2d2b9b8813a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c37ac9ed-5fa2-484b-ad54-0e73b5b32365"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c4cd304c-1cee-472e-990b-c999944ca825"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8353168-5a71-4247-9083-9217a3c5ead4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c9eeb650-f0a0-42f4-9618-cd2e4ecca6e5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("caf07902-d1ac-4b72-bf66-60895193d296"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ce841829-e222-45d4-93b7-8c1158c4212e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cec96b28-03d6-4297-8c80-3f9c030c1ec5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfa452b9-e571-48c2-ae62-00143475ae22"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d019b3ff-d9c6-4990-8744-ec338d8177f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d32f5e41-4926-4df0-858f-2efa1a9ce9fb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d75d56a9-458e-4643-9f16-6a7b721aa0c7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d81713f9-95f9-4711-8215-0b012e7f32f8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9f919d1-4c86-4e13-b70a-8f8483e66cee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da2935cb-dd92-49df-bbcc-116932ca60ce"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e3b13380-2756-4ac3-9fc3-db866421848e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e63c8526-5f2d-40b0-a9ec-d43252f9df20"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7564e36-8705-4072-91f0-cdd49ebdf291"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e8d3d2a6-2c5c-4be4-adec-bb8afc184ac7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ebe8f767-538e-4b61-b820-aa10095cac9a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ec2b752a-64d5-4829-8d82-e1c70a1e2aab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ede9bd29-e7da-4f85-af48-dfc4948faa55"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f5a9e094-5454-4750-bb27-54b8c8cde681"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fda97bf7-eb42-46a6-a7ea-a5102d3bdfd5"));
        }
    }
}
