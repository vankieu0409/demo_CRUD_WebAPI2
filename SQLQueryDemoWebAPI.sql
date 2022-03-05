use DemoDPOTECH
GO

-- Insert rows into table 'TableName' in schema '[dbo]'
INSERT INTO [dbo].[Class]
    ( -- Columns to insert data into
    [NameClass] , [Classroom]
    )
VALUES
    ( -- First row: values for the columns in the list above
        N'IT16312', N'P307'
),
    ( -- Second row: values for the columns in the list above
        N'TI16313', N'P305'
)
-- Add more rows here
GO


-- Insert rows into table 'Student' in schema '[dbo]'
INSERT INTO [dbo].[Student]
    ( -- Columns to insert data into
    [IdClass], [Name], [birth]
    )
VALUES
    ( -- First row: values for the columns in the list above
        1, N'Nguyễn Văn Kiều', '2/22/1998'
),
    ( -- Second row: values for the columns in the list above
        2, N'Lê văn Lưu', '2/22/2002'
),
    ( -- Second row: values for the columns in the list above
        1, N'Phí Thị Trang', '3/19/2002'
),
    ( -- Second row: values for the columns in the list above
        2, N'Nguyễn Khắc Kiên', '6/18/2002'
)
-- Add more rows here
GO

-- Select rows from a Table or View '[Student]' in schema '[dbo]'
SELECT Student.Name
FROM Student JOIN Class ON Student.IdClass = Class.IdClass
WHERE NameClass like N'IT16312'
GO