-- 001_CreateImagesTable.sql

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Images' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    EXEC('
    CREATE TABLE dbo.Images (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        ImageData VARBINARY(MAX) NOT NULL,
        Width INT NOT NULL,
        Height INT NOT NULL,
        PixelFormat NVARCHAR(50) NOT NULL,
        Path NVARCHAR(200) NOT NULL
    )
    ')
END
