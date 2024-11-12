INSERT INTO Images (Name, ImageData, Width, Height, PixelFormat, Path)
VALUES (@Name, @ImageData, @Width, @Height, @PixelFormat, @Path);
SELECT CAST(SCOPE_IDENTITY() AS INT);
