-- public."Category" definition

-- Drop table

-- DROP TABLE public."Category";

CREATE TABLE public."Category" (
	"ID" uuid NOT NULL,
	"Name" text NOT NULL,
	"Description" text NOT NULL,
	"Discount" int4 NOT NULL,
	"DT_UPDATED" timestamptz NOT NULL,
	"DT_CREATED" timestamptz NOT NULL,
	CONSTRAINT "PK_Category" PRIMARY KEY ("ID")
);


-- public."User" definition

-- Drop table

-- DROP TABLE public."User";

CREATE TABLE public."User" (
	"ID" uuid NOT NULL,
	"Name" text NOT NULL,
	"Email" text NOT NULL,
	"Gender" text NOT NULL,
	"CPFCNPJ" text NOT NULL,
	"AcessHash" text NOT NULL,
	"DT_UPDATED" timestamptz NOT NULL,
	"DT_CREATED" timestamptz NOT NULL,
	CONSTRAINT "PK_User" PRIMARY KEY ("ID")
);


-- public."Address" definition

-- Drop table

-- DROP TABLE public."Address";

CREATE TABLE public."Address" (
	"ID" uuid NOT NULL,
	"UserID" uuid NOT NULL,
	"StreetAddress" text NOT NULL,
	"City" text NOT NULL,
	"State" text NOT NULL,
	"CEP" text NOT NULL,
	"Active" bool NOT NULL,
	"DT_UPDATED" timestamptz NOT NULL,
	"DT_CREATED" timestamptz NOT NULL,
	CONSTRAINT "PK_Address" PRIMARY KEY ("ID"),
	CONSTRAINT "FK_Address_User_UserID" FOREIGN KEY ("UserID") REFERENCES public."User"("ID") ON DELETE CASCADE
);
CREATE INDEX "IX_Address_UserID" ON public."Address" USING btree ("UserID");


-- public."Checkout" definition

-- Drop table

-- DROP TABLE public."Checkout";

CREATE TABLE public."Checkout" (
	"ID" uuid NOT NULL,
	"UserId" uuid NOT NULL,
	"Discount" int4 NOT NULL,
	"ShippingCost" numeric NOT NULL,
	"DT_UPDATED" timestamptz NOT NULL,
	"DT_CREATED" timestamptz NOT NULL,
	CONSTRAINT "PK_Checkout" PRIMARY KEY ("ID"),
	CONSTRAINT "FK_Checkout_User_UserId" FOREIGN KEY ("UserId") REFERENCES public."User"("ID") ON DELETE CASCADE
);
CREATE INDEX "IX_Checkout_UserId" ON public."Checkout" USING btree ("UserId");


-- public."Products" definition

-- Drop table

-- DROP TABLE public."Products";

CREATE TABLE public."Products" (
	"ID" uuid NOT NULL,
	"CategoryID" uuid NOT NULL,
	"Name" text NOT NULL,
	"Value" int4 NOT NULL,
	"Description" text NOT NULL,
	"Active" bool NOT NULL,
	"Discount" int4 NOT NULL,
	"DT_UPDATED" timestamptz NOT NULL,
	"DT_CREATED" timestamptz NOT NULL,
	CONSTRAINT "PK_Products" PRIMARY KEY ("ID"),
	CONSTRAINT "FK_Products_Category_CategoryID" FOREIGN KEY ("CategoryID") REFERENCES public."Category"("ID") ON DELETE CASCADE
);
CREATE INDEX "IX_Products_CategoryID" ON public."Products" USING btree ("CategoryID");


-- public."CheckoutProduct" definition

-- Drop table

-- DROP TABLE public."CheckoutProduct";

CREATE TABLE public."CheckoutProduct" (
	"CheckoutId" uuid NOT NULL,
	"ProductsId" uuid NOT NULL,
	CONSTRAINT "PK_CheckoutProduct" PRIMARY KEY ("CheckoutId", "ProductsId"),
	CONSTRAINT "FK_CheckoutProduct_Checkout_CheckoutId" FOREIGN KEY ("CheckoutId") REFERENCES public."Checkout"("ID") ON DELETE CASCADE,
	CONSTRAINT "FK_CheckoutProduct_Products_ProductsId" FOREIGN KEY ("ProductsId") REFERENCES public."Products"("ID") ON DELETE CASCADE
);
CREATE INDEX "IX_CheckoutProduct_ProductsId" ON public."CheckoutProduct" USING btree ("ProductsId");