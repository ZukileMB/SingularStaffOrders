
  SET IDENTITY_INSERT [dbo].[Products] ON 

Merge INTO [dbo].[Products] AS target
Using (Values (1 ,  N'Microsoft Lumia 640 XL LTE', N'With an octa-core processor and a 5.7” Quad HD display, it’s the most powerful phone we’ve ever built. With USB-C Fast Charging, an extra-large battery, and wireless charging, it’s pure power that’s easy to charge. Demanding apps, serious games, and the creativity tools you love – get a Lumia 950 XL Dual SIM and discover exciting new ways to do great things.2', 1620, N'Nokia Lumia 830.jpg'),
			  (2 ,  N'Microsoft Edge', N'3 GB RAM | 32 GB ROM | Expandable Upto 200 GB20MP Primary Camera | 5MP Front|Qualcomm Snapdragon 808 Processor', 2900, N'MicrosoftEdge.jpg'),
			  (3 ,  N'Microsoft Lumia 950', N'With an octa-core processor and a 5.7” Quad HD display, it’s the most powerful phone we’ve ever built. With USB-C Fast Charging, an extra-large battery, and wireless charging, it’s pure power that’s easy to charge. Demanding apps, serious games, and the creativity tools you love – get a Lumia 950 XL Dual SIM and discover exciting new ways to do great things.2',2100, N'Microsoft Lumia 950 XL Dual SIM.jpg'),
			  (4 ,  N'MicrosoftXL', N'SIM card type: Nano SIM AV connectors: 3.5 mm stereo headset connector Charging connectors: Micro-USB System connectors: Micro-USB-B USB: USB 2.0 Bluetooth: Bluetooth 4.0 Bluetooth profiles: Hands-free profile (HFP) 1.6, Object Push profile (OPP) 1.1, Generic Attribute Profile (GATT), Phone Book Access Profile (PBAP) 1.1, Personal Area Network Profile (PAN) 1.0, Advanced Audio Distribution Profile (A2DP) 1.2, Audio/Video Remote Control Profile (AVRCP) 1.4',50,  N'MicrosoftXL.jpg'),	  
			  (5 ,  N'Hp 15 Core i5', N'11th Gen Intel(R) Core(TM) i5-1135G7 @ 2.40GHz   2.42 GHz',22500 ,N'Hp15.jpg'),
			  (6 ,  N'Hp 15 Intel Inside',N'11th Gen Intel(R) Core(TM) celeron-1135G7 @ 2.40GHz   2.42 GHz',4500, N'Hp14s.png'),
			  (7 ,  N'Huawei Intel Core i3',N'Huawei Intel Core i3-1135G7 @ 2.40GHz   2.42 GHz',8995, N'Huawei.jpg'),
			  (8 , N'Apple iPhone 13 Pro 256GB', N'6.1 inch XDR display with ProMotion | Cinematic mode for added depth of field | A15 Bionic chip for fast performance | Advanced dual camera system with 12MP | 12MP TrueDepth front camera | Durable design with ceramic shield',  23995, N'Iphone13.jpg'),
			  (9 , N'MacBook Pro', N'MacBook Pro Intel Core i3-1135G7 @ 2.40GHz   2.42 GHz',16900, N'MacBook.jpg'),
			  (10 , N'nokia-laptop ',N'MacBook Pro Intel Core i3-1135G7 @ 2.40GHz   2.42 GHz',3990, N'nokia-laptop.jpg')
		) as source ( [ProductId], [ProductTitle], [Description], [UnitPrice],[Image])
ON target.[ProductId] = source.[ProductId]

WHEN MATCHED THEN
	Update set
	 [ProductTitle]		= source.[ProductTitle],
	 [Description]				= source.[Description], 
	 [UnitPrice]	= source.[UnitPrice],
	 [Image]		= source.[Image]

WHEN NOT MATCHED THEN
	INSERT
	 (
		 [ProductId], 
		 [ProductTitle],
		 [Description], 
		 [UnitPrice],
		 [Image]
	 )
	 VALUES
	 (
		 source.[ProductId], 
		 source.[ProductTitle],
		 source.[Description], 
		 source.[UnitPrice],
		 source.[Image] 
	 );


SET IDENTITY_INSERT [dbo].[Products] OFF