using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace products.infrastructure.Migrations
{
    public partial class InitialSeeds : Migration
    {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
        INSERT INTO public.""User""
        (""ID"", ""Name"", ""Email"", ""Gender"", ""CPFCNPJ"", ""AcessHash"", ""DT_UPDATED"", ""DT_CREATED"")
        VALUES
        ('3d6bfea0-1662-4c3c-b961-e42959b3ecf2', 'Renato Santos', 'renato.teste@teste.com', 'Male', '12345678900', '7c74d0715efdfa37f9f4f1f5d62c642acfd5af361be004d62033615d8e3b2605a79f12905b539b15aa6647de6630c3016f2509725f42fbcfb5ac0f0a45c94aaf', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('fdd54d83-8dbe-4fce-8a8f-e458634bcf90', 'Jane Smith', 'jane.smith@example.com', 'Female', '98765432100', '7c74d0715efdfa37f9f4f1f5d62c642acfd5af361be004d62033615d8e3b2605a79f12905b539b15aa6647de6630c3016f2509725f42fbcfb5ac0f0a45c94aaf', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('fdd54d83-8dbe-4fce-8a8f-e458634bcf91', 'Michael Johnson', 'michael.johnson@example.com', 'Male', '45678912300', '7c74d0715efdfa37f9f4f1f5d62c642acfd5af361be004d62033615d8e3b2605a79f12905b539b15aa6647de6630c3016f2509725f42fbcfb5ac0f0a45c94aaf', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('82b9208a-e4c2-4f70-bf71-6e79f732bc57', 'Emily Davis', 'emily.davis@example.com', 'Female', '65432198700', '7c74d0715efdfa37f9f4f1f5d62c642acfd5af361be004d62033615d8e3b2605a79f12905b539b15aa6647de6630c3016f2509725f42fbcfb5ac0f0a45c94aaf', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('5b2e4daf-20f0-43d2-aade-7925b6cd80c1', 'Christopher Wilson', 'christopher.wilson@example.com', 'Male', '78912345600', '7c74d0715efdfa37f9f4f1f5d62c642acfd5af361be004d62033615d8e3b2605a79f12905b539b15aa6647de6630c3016f2509725f42fbcfb5ac0f0a45c94aaf', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('5b2e4daf-20f0-43d2-aade-7925b6cd80c2', 'Jessica Martinez', 'jessica.martinez@example.com', 'Female', '32165498700', '7c74d0715efdfa37f9f4f1f5d62c642acfd5af361be004d62033615d8e3b2605a79f12905b539b15aa6647de6630c3016f2509725f42fbcfb5ac0f0a45c94aaf', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('5b2e4daf-20f0-43d2-aade-7925b6cd80c3', 'Daniel Taylor', 'daniel.taylor@example.com', 'Male', '98765412300', '7c74d0715efdfa37f9f4f1f5d62c642acfd5af361be004d62033615d8e3b2605a79f12905b539b15aa6647de6630c3016f2509725f42fbcfb5ac0f0a45c94aaf', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('5b2e4daf-20f0-43d2-aade-7925b6cd80c4', 'Emma Anderson', 'emma.anderson@example.com', 'Female', '45678932100', '7c74d0715efdfa37f9f4f1f5d62c642acfd5af361be004d62033615d8e3b2605a79f12905b539b15aa6647de6630c3016f2509725f42fbcfb5ac0f0a45c94aaf', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('5b2e4daf-20f0-43d2-aade-7925b6cd80c5', 'Andrew Thomas', 'andrew.thomas@example.com', 'Male', '65412378900', '7c74d0715efdfa37f9f4f1f5d62c642acfd5af361be004d62033615d8e3b2605a79f12905b539b15aa6647de6630c3016f2509725f42fbcfb5ac0f0a45c94aaf', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('5b2e4daf-20f0-43d2-aade-7925b6cd80c6', 'Olivia Garcia', 'olivia.garcia@example.com', 'Female', '78932145600', '7c74d0715efdfa37f9f4f1f5d62c642acfd5af361be004d62033615d8e3b2605a79f12905b539b15aa6647de6630c3016f2509725f42fbcfb5ac0f0a45c94aaf', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

        INSERT INTO public.""Address""
        (""ID"", ""UserID"", ""StreetAddress"", ""City"", ""State"", ""CEP"", ""Active"", ""DT_UPDATED"", ""DT_CREATED"")
        VALUES
        ('f6dba8c9-a4ea-41b5-9802-a16198d3c6de','3d6bfea0-1662-4c3c-b961-e42959b3ecf2', '123 Main St', 'New York', 'NY', '10001', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('d9dc9b42-9490-44fa-91ed-3e62c7eaadbb','fdd54d83-8dbe-4fce-8a8f-e458634bcf90','456 Elm St', 'Los Angeles', 'CA', '90001', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('d9dc9b42-9490-44fa-91ed-3e62c7eaadb1','fdd54d83-8dbe-4fce-8a8f-e458634bcf90', '789 Oak St', 'Chicago', 'IL', '60601', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('78afd312-c43c-4d6d-952f-dc89b4d0a97d','82b9208a-e4c2-4f70-bf71-6e79f732bc57', '101 Pine St', 'Houston', 'TX', '77001', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('85e4708a-db32-4c0b-b638-9a7ba5d73b81','5b2e4daf-20f0-43d2-aade-7925b6cd80c1', '222 Maple St', 'San Francisco', 'CA', '94101', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('85e4708a-db32-4c0b-b638-9a7ba5d73b82', '5b2e4daf-20f0-43d2-aade-7925b6cd80c2', '333 Cedar St', 'Boston', 'MA', '02101', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('85e4708a-db32-4c0b-b638-9a7ba5d73b83', '5b2e4daf-20f0-43d2-aade-7925b6cd80c3', '444 Birch St', 'Seattle', 'WA', '98101', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('85e4708a-db32-4c0b-b638-9a7ba5d73b84', '5b2e4daf-20f0-43d2-aade-7925b6cd80c4', '555 Spruce St', 'Miami', 'FL', '33101', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('85e4708a-db32-4c0b-b638-9a7ba5d73b85', '5b2e4daf-20f0-43d2-aade-7925b6cd80c5', '666 Walnut St', 'Dallas', 'TX', '75201', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('85e4708a-db32-4c0b-b638-9a7ba5d73b86', '5b2e4daf-20f0-43d2-aade-7925b6cd80c6', '777 Willow St', 'Atlanta', 'GA', '30301', true, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);


        INSERT INTO public.""Category""
        (""ID"", ""Name"", ""Description"", ""Discount"", ""DT_UPDATED"", ""DT_CREATED"")
        VALUES
        ('c14e1be4-4a61-4cf9-85b0-286a0f153c2e', 'Electronics', 'Category for electronic devices', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('c28994c6-0c6c-4b50-a0e0-8a7c9d2c6a6b', 'Clothing', 'Category for clothing items', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('7aeb7311-f2cb-4e05-8e76-2df5245432fb', 'Home Appliances', 'Category for home appliances', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('b26e6c7e-1e67-4ad7-8485-01c3fb9c98a9', 'Books', 'Category for books and literature', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('f3a08556-d6d9-4ad9-b484-201b0476db8c', 'Sports', 'Category for sports equipment', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('9f48790b-7e24-4c13-9823-bb5e6f3d39ec', 'Furniture', 'Category for furniture items', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('9cd2925a-d53c-4a19-9441-4dc982acab9f', 'Toys', 'Category for childrens toys', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('e6dfaa01-5170-46d4-8d11-51d8b512c8e7', 'Beauty', 'Category for beauty and personal care products', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('10c59b27-cad3-4df7-94ef-3ff9d3494859', 'Food', 'Category for food and beverages', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('e00166b4-9d9d-4fe0-96b8-4e9a3e93a66d', 'Automotive', 'Category for automotive products', 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

        INSERT INTO public.""Products""
        (""ID"", ""CategoryID"", ""Name"", ""Value"", ""Description"", ""Active"", ""Discount"", ""DT_UPDATED"", ""DT_CREATED"")
        VALUES
        ('6e0b8d7f-e8bc-41b2-bf59-53d9a5116f21', 'c14e1be4-4a61-4cf9-85b0-286a0f153c2e', 'Smartphone', 1000, 'High-end smartphone with latest features', true, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('e61b0db4-7961-49bb-bb0d-431dc13b191f', 'c14e1be4-4a61-4cf9-85b0-286a0f153c2e', 'Laptop', 1500, 'Powerful laptop for work and entertainment', true, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('dfb9ab90-9242-4f81-b4a9-0d00918f7338', 'c28994c6-0c6c-4b50-a0e0-8a7c9d2c6a6b', 'T-shirt', 20, 'Comfortable cotton T-shirt for everyday wear', true, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('0d7e6aa1-6a2c-418a-8010-3ac2c67b3c68', 'c28994c6-0c6c-4b50-a0e0-8a7c9d2c6a6b', 'Jeans', 50, 'Classic denim jeans for men and women', true, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('1a4826eb-c9d9-41c4-b5e4-3df91c369e7c', '7aeb7311-f2cb-4e05-8e76-2df5245432fb', 'Refrigerator', 1200, 'Large capacity refrigerator with advanced cooling technology', true, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('b1441812-fb2e-48e9-bcfc-6753d8fcf11c', '7aeb7311-f2cb-4e05-8e76-2df5245432fb', 'Washing Machine', 800, 'Front-loading washing machine with multiple wash cycles', true, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('78ad1e1b-4c9f-4a60-9d48-25c002a53e08', 'b26e6c7e-1e67-4ad7-8485-01c3fb9c98a9', 'The Great Gatsby', 15, 'Classic novel by F. Scott Fitzgerald', true, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('d71bce6f-6034-4135-b21a-31891d7fb556', 'b26e6c7e-1e67-4ad7-8485-01c3fb9c98a9', 'To Kill a Mockingbird', 12, 'Novel by Harper Lee set in the American South', true, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('ab2d81b9-118f-4d28-82f8-5d8333f8378f', 'f3a08556-d6d9-4ad9-b484-201b0476db8c', 'Football', 30, 'Official size and weight football for recreational play', true, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
        ('7f94e6fc-4da4-4a35-b1d6-bc7f4910c9df', 'f3a08556-d6d9-4ad9-b484-201b0476db8c', 'Basketball', 25, 'Durable basketball suitable for indoor and outdoor use', true, 0, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
        ");
    }

    protected override void Down(MigrationBuilder migrationBuilder){}
    }
}
