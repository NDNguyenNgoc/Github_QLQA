USE [QuanLyQuanAn]
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([TF_ID], [TF_Name], [TF_Status]) VALUES (1, N'Bàn 1', N'Có người')
INSERT [dbo].[TableFood] ([TF_ID], [TF_Name], [TF_Status]) VALUES (2, N'Bàn 2', N'Trống')
INSERT [dbo].[TableFood] ([TF_ID], [TF_Name], [TF_Status]) VALUES (3, N'Bàn 3', N'Trống')
INSERT [dbo].[TableFood] ([TF_ID], [TF_Name], [TF_Status]) VALUES (4, N'Bàn 4', N'Có người')
INSERT [dbo].[TableFood] ([TF_ID], [TF_Name], [TF_Status]) VALUES (5, N'Bàn 5', N'Trống')
INSERT [dbo].[TableFood] ([TF_ID], [TF_Name], [TF_Status]) VALUES (6, N'Bàn 6', N'Trống')
INSERT [dbo].[TableFood] ([TF_ID], [TF_Name], [TF_Status]) VALUES (7, N'Bàn 7', N'Trống')
INSERT [dbo].[TableFood] ([TF_ID], [TF_Name], [TF_Status]) VALUES (8, N'Bàn 8', N'Trống')
INSERT [dbo].[TableFood] ([TF_ID], [TF_Name], [TF_Status]) VALUES (9, N'Bàn 9', N'Trống')
INSERT [dbo].[TableFood] ([TF_ID], [TF_Name], [TF_Status]) VALUES (10, N'Bàn 10', N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([S_ID], [S_Name], [S_PhoneNumber], [S_IdentityCard], [S_Salary]) VALUES (1, N'Nguyễn Tấn Ngọc', N'0704814077', N'0123456789', 10000000)
INSERT [dbo].[Staff] ([S_ID], [S_Name], [S_PhoneNumber], [S_IdentityCard], [S_Salary]) VALUES (3, N'Ôn Đinh Khang', N'0987654321', N'0123456799', 10000000)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([B_ID], [DateCheckIn], [DateCheckOut], [B_IDTable], [B_IDStaff], [B_Status], [B_Discount], [B_TotalPrice], [B_TotalFunds]) VALUES (1, CAST(N'2022-01-23' AS Date), CAST(N'2022-01-23' AS Date), 1, 1, 1, 0, 80000, 35000)
INSERT [dbo].[Bill] ([B_ID], [DateCheckIn], [DateCheckOut], [B_IDTable], [B_IDStaff], [B_Status], [B_Discount], [B_TotalPrice], [B_TotalFunds]) VALUES (2, CAST(N'2022-01-23' AS Date), CAST(N'2022-01-24' AS Date), 2, 1, 1, 0, 70000, 35000)
INSERT [dbo].[Bill] ([B_ID], [DateCheckIn], [DateCheckOut], [B_IDTable], [B_IDStaff], [B_Status], [B_Discount], [B_TotalPrice], [B_TotalFunds]) VALUES (4, CAST(N'2022-01-24' AS Date), CAST(N'2022-01-24' AS Date), 1, 1, 1, 10, 18000, 10000)
INSERT [dbo].[Bill] ([B_ID], [DateCheckIn], [DateCheckOut], [B_IDTable], [B_IDStaff], [B_Status], [B_Discount], [B_TotalPrice], [B_TotalFunds]) VALUES (5, CAST(N'2022-01-24' AS Date), NULL, 7, 1, 0, 0, NULL, NULL)
INSERT [dbo].[Bill] ([B_ID], [DateCheckIn], [DateCheckOut], [B_IDTable], [B_IDStaff], [B_Status], [B_Discount], [B_TotalPrice], [B_TotalFunds]) VALUES (8, CAST(N'2022-01-24' AS Date), NULL, 3, 1, 0, 0, NULL, NULL)
INSERT [dbo].[Bill] ([B_ID], [DateCheckIn], [DateCheckOut], [B_IDTable], [B_IDStaff], [B_Status], [B_Discount], [B_TotalPrice], [B_TotalFunds]) VALUES (9, CAST(N'2022-01-24' AS Date), NULL, 4, 1, 0, 0, NULL, NULL)
INSERT [dbo].[Bill] ([B_ID], [DateCheckIn], [DateCheckOut], [B_IDTable], [B_IDStaff], [B_Status], [B_Discount], [B_TotalPrice], [B_TotalFunds]) VALUES (10, CAST(N'2022-01-24' AS Date), NULL, 1, 3, 0, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoryFood] ON 

INSERT [dbo].[CategoryFood] ([CF_ID], [CF_Name]) VALUES (1, N'Ăn Sáng')
INSERT [dbo].[CategoryFood] ([CF_ID], [CF_Name]) VALUES (2, N'Ăn Trưa')
INSERT [dbo].[CategoryFood] ([CF_ID], [CF_Name]) VALUES (3, N'Ăn Tối')
INSERT [dbo].[CategoryFood] ([CF_ID], [CF_Name]) VALUES (4, N'Nước Uống')
SET IDENTITY_INSERT [dbo].[CategoryFood] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([F_ID], [F_Name], [F_IDCategory], [F_Funds], [F_Price]) VALUES (1, N'Cơm tấm', 1, 5000, 10000)
INSERT [dbo].[Food] ([F_ID], [F_Name], [F_IDCategory], [F_Funds], [F_Price]) VALUES (2, N'Hủ tiếu', 1, 10000, 20000)
INSERT [dbo].[Food] ([F_ID], [F_Name], [F_IDCategory], [F_Funds], [F_Price]) VALUES (3, N'Trà đá đường', 4, 5000, 10000)
INSERT [dbo].[Food] ([F_ID], [F_Name], [F_IDCategory], [F_Funds], [F_Price]) VALUES (5, N'Cơm gà', 2, 10000, 25000)
INSERT [dbo].[Food] ([F_ID], [F_Name], [F_IDCategory], [F_Funds], [F_Price]) VALUES (6, N'Cơm sườn', 2, 10000, 25000)
INSERT [dbo].[Food] ([F_ID], [F_Name], [F_IDCategory], [F_Funds], [F_Price]) VALUES (7, N'Cháo lòng', 3, 8000, 20000)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfor] ON 

INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (1, 1, 1, 2)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (2, 1, 2, 1)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (3, 1, 5, 1)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (4, 1, 6, 1)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (5, NULL, 6, 5)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (6, NULL, 1, 2)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (7, NULL, 1, 2)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (8, 4, 2, 1)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (9, 10, 2, 1)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (10, 2, 1, 2)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (11, 9, 2, 1)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (12, 9, 5, 1)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (13, 9, 7, 1)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (15, 9, 1, 2)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (16, NULL, 1, 2)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (17, NULL, 2, 1)
INSERT [dbo].[BillInfor] ([BI_ID], [BI_IDBill], [BI_IDFood], [BI_Total]) VALUES (18, NULL, 3, 1)
SET IDENTITY_INSERT [dbo].[BillInfor] OFF
GO
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [A_IDStaff], [A_Type]) VALUES (N'Admin', N'Nguyễn Tấn Ngọc', N'1', 1, 0)
INSERT [dbo].[Account] ([UserName], [DisplayName], [PassWord], [A_IDStaff], [A_Type]) VALUES (N'Staff', N'Ôn Đình Khang', N'1', 3, 1)
GO
