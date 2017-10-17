DECLARE @Workspace INT = (SELECT ArtifactID FROM EDDSDBO.Artifact WHERE ArtifactTypeID = 8)

DECLARE @ArtifactTypeID INT = (SELECT DescriptorArtifactTypeID FROM EDDSDBO.ObjectType OT
  INNER JOIN [EDDSDBO].[ArtifactGuid] ARG ON ARG.ArtifactID = OT.ArtifactID
  WHERE ARG.ArtifactGuid = @Type
);

INSERT INTO [EDDSDBO].[Artifact] (ArtifactTypeID, ParentArtifactID, ContainerID, CreatedOn, CreatedBy, LastModifiedOn, 
									LastModifiedBy, AccessControlListID, AccessControlListIsInherited, TextIdentifier, Keywords, Notes, DeleteFlag)
VALUES (@ArtifactTypeID, @Workspace, @Workspace, GETDATE(), @User, GETDATE(), @User, 1, 1, @CaseName, '', '', 0)

DECLARE @ArtifactID INT = SCOPE_IDENTITY()

INSERT INTO [EDDSDBO].[Case] (ArtifactID, Name)
VALUES (@ArtifactID, @CaseName)

INSERT INTO [EDDSDBO].[ArtifactAncestry] (AncestorArtifactID, ArtifactID)
VALUES (@Workspace, @ArtifactID)

INSERT INTO	[EDDSDBO].[ArtifactAncestry] (AncestorArtifactID, ArtifactID)
SELECT AncestorArtifactID, @ArtifactID
FROM [EDDSDBO].[ArtifactAncestry] WHERE ArtifactID = @Workspace

INSERT INTO [EDDSDBO].[AuditRecord] (ArtifactID, Action, Details, UserID, TimeStamp, RequestOrigination, RecordOrigination) 
values (@ArtifactID, 2, '', @User,GETDATE(),'','')

SELECT @ArtifactID AS ArtifactID