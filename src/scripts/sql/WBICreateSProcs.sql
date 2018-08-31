USE finskewdb
GO

-- WBI stored procedures --

CREATE PROCEDURE uspUpsertWBITopics
AS
MERGE [WBITopics] as target1
	USING [WBIStaging_WBITopics] as staging1
	ON target1.Id = staging1.Id
	WHEN MATCHED THEN
		UPDATE SET
			target1.TopicValue = staging1.TopicValue,
			target1.SourceNote = staging1.SourceNote
	WHEN NOT MATCHED BY TARGET THEN
		INSERT (TopicValue, SourceNote) 
		VALUES (TopicValue, SourceNote);
DELETE FROM [WBIStaging_WBITopics];
GO