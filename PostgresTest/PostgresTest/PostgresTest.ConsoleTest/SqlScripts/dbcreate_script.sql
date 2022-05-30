CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE SEQUENCE "CustomerNumbers" AS integer START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;

CREATE SEQUENCE "ProductNumbers" AS integer START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;

CREATE TABLE "Customers" (
    "CustomerID" integer NOT NULL DEFAULT (nextval('"CustomerNumbers"')),
    "Name" text NOT NULL,
    CONSTRAINT "PK_Customers" PRIMARY KEY ("CustomerID")
);

CREATE TABLE "Products" (
    "ProductID" integer NOT NULL DEFAULT (nextval('"ProductNumbers"')),
    "Name" text NOT NULL,
    CONSTRAINT "PK_Products" PRIMARY KEY ("ProductID")
);

CREATE TABLE "Purchases" (
    "CustomerID" integer NOT NULL,
    "ProductID" integer NOT NULL,
    CONSTRAINT "PK_Purchases" PRIMARY KEY ("CustomerID", "ProductID"),
    CONSTRAINT "FK_Purchases_Customers_CustomerID" FOREIGN KEY ("CustomerID") REFERENCES "Customers" ("CustomerID") ON DELETE CASCADE,
    CONSTRAINT "FK_Purchases_Products_ProductID" FOREIGN KEY ("ProductID") REFERENCES "Products" ("ProductID") ON DELETE CASCADE
);

CREATE INDEX "IX_Purchases_ProductID" ON "Purchases" ("ProductID");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220524195640_InitialMigration', '6.0.5');

COMMIT;

