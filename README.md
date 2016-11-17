# SecurityWorkshop

These are the database scripts.

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CreditCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](5000) NOT NULL,
	[Number] [varchar](5000) NOT NULL,
	[CVV] [varchar](5000) NOT NULL,
	[ExpiryMonth] [int] NOT NULL,
	[ExpiryYear] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


CREATE USER [WoksUser] FOR LOGIN [WoksUser] WITH DEFAULT_SCHEMA=[dbo]
GO


INSERT INTO CreditCards (Name, Number, CVV, ExpiryMonth, ExpiryYear)
VALUES ('Mr Happy', '1234123412341234', '123', 1, 2017);

INSERT INTO CreditCards (Name, Number, CVV, ExpiryMonth, ExpiryYear)
VALUES ('Mr Greedy', '8976347896349783', '563', 10, 2017);

INSERT INTO CreditCards (Name, Number, CVV, ExpiryMonth, ExpiryYear)
VALUES ('Mr Small', '1111111111111111', '821', 6, 2017);

INSERT INTO CreditCards (Name, Number, CVV, ExpiryMonth, ExpiryYear)
VALUES ('Mr Noisy', '7078376856478934', '765', 3, 2017);

INSERT INTO CreditCards (Name, Number, CVV, ExpiryMonth, ExpiryYear)
VALUES ('Mr Messy', '4562358123782340', '383', 1, 2018);
