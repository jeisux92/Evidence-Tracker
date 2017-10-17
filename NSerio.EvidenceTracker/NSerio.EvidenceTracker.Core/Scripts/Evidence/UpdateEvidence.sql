UPDATE EVI
SET EVI.Date = @Date, EVI.Latitude = @Latitude, EVI.Longitude = @Longitude
FROM [EDDSDBO].[EvidenceTracker] EVI
WHERE EVI.ArtifactID = @ID