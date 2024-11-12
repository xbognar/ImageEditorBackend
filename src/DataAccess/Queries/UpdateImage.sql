UPDATE Images
SET Name = @Name,
    ImageData = @ImageData,
    Width = @Width,
    Height = @Height,
    PixelFormat = @PixelFormat,
    Path = @Path
WHERE Id = @Id;
