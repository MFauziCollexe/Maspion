USE [Maspion]
GO
/****** Object:  Table [dbo].[AR_PEMBAYARAN_KONTAN_DETAIL_CNDN]    Script Date: 16/03/2021 14:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AR_PEMBAYARAN_KONTAN_DETAIL_CNDN](
	[ID_TRANSAKSI] [varchar](50) NULL,
	[NO_TRANSAKSI] [varchar](50) NULL,
	[ID_CNDN] [varchar](50) NULL,
	[NO_CNDN] [varchar](50) NULL,
	[NOMINAL] [float] NULL
) ON [PRIMARY]
GO
