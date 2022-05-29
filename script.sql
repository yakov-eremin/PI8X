-- Create tables section -------------------------------------------------

-- Table Treaties

CREATE TABLE `Treaties`
(
  `ID_Treatie` Bigint NOT NULL,
  `Number_Of_Treatie` Text NOT NULL,
  `Start_Date` Date NOT NULL,
  `End_Date` Date NOT NULL,
  `ID_Customer` Bigint NOT NULL,
  `Summary` Float NOT NULL,
  `Status` Text NOT NULL,
  `Claims_Days` Int NOT NULL,
  `Swap_Days` Int NOT NULL,
  `Supply_Delay` Int NOT NULL,
  `Fine` Float NOT NULL
)
;

CREATE INDEX `IX_Relationship1` ON `Treaties` (`ID_Customer`)
;

ALTER TABLE `Treaties` ADD PRIMARY KEY (`ID_Treatie`)
;

-- Table Customer

CREATE TABLE `Customer`
(
  `ID_Customer` Bigint NOT NULL,
  `Organization_Name` Text NOT NULL,
  `Organization_Form` Text NOT NULL,
  `Director_FIO` Text NOT NULL,
  `Law_Address` Text NOT NULL,
  `Mail_Address` Text NOT NULL,
  `INN` Text NOT NULL,
  `KPP` Text NOT NULL,
  `Checking_Account` Text NOT NULL,
  `Korr_Account` Text NOT NULL,
  `BIK` Text NOT NULL,
  `ID_OKPO` Bigint NOT NULL,
  `ID_FIAS` Bigint NOT NULL
)
;

CREATE INDEX `IX_Relationship56` ON `Customer` (`ID_FIAS`)
;

ALTER TABLE `Customer` ADD PRIMARY KEY (`ID_Customer`)
;

-- Table OKEI

CREATE TABLE `OKEI`
(
  `Unit` Text NOT NULL,
  `ID_OKEI` Bigint NOT NULL
)
;

ALTER TABLE `OKEI` ADD PRIMARY KEY (`ID_OKEI`)
;

-- Table OKPO

CREATE TABLE `OKPO`
(
  `ID_OKPO` Bigint NOT NULL
)
;

ALTER TABLE `OKPO` ADD PRIMARY KEY (`ID_OKPO`)
;

-- Table Orders

CREATE TABLE `Orders`
(
  `ID_Order` Bigint NOT NULL,
  `Nubmer_Of_Order` Text NOT NULL,
  `Start_Date` Date NOT NULL,
  `ID_Treatie` Bigint NOT NULL,
  `Summary` Float NOT NULL,
  `Address` Text NOT NULL
)
;

CREATE INDEX `IX_Relationship45` ON `Orders` (`ID_Treatie`)
;

ALTER TABLE `Orders` ADD PRIMARY KEY (`ID_Order`)
;

-- Table Goods_In_Order

CREATE TABLE `Goods_In_Order`
(
  `ID_Goods_In_Order` Bigint NOT NULL,
  `ID_Order` Bigint NOT NULL,
  `Name` Text NOT NULL,
  `Usability` Text,
  `Requierements` Text,
  `Vendor_Code` Text,
  `Price` Float NOT NULL,
  `Amount` Float NOT NULL,
  `ID_OKEI` Bigint NOT NULL
)
;

CREATE INDEX `IX_Relationship34` ON `Goods_In_Order` (`ID_OKEI`)
;

ALTER TABLE `Goods_In_Order` ADD PRIMARY KEY (`ID_Goods_In_Order`)
;

-- Table FIAS

CREATE TABLE `FIAS`
(
  `Address_Of_Reciever` Text NOT NULL,
  `ID_FIAS` Bigint NOT NULL
)
;

ALTER TABLE `FIAS` ADD PRIMARY KEY (`ID_FIAS`)
;

-- Create foreign keys (relationships) section -------------------------------------------------

ALTER TABLE `Treaties` ADD CONSTRAINT `Relationship1` FOREIGN KEY (`ID_Customer`) REFERENCES `Customer` (`ID_Customer`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `Customer` ADD CONSTRAINT `Relationship41` FOREIGN KEY (`ID_OKPO`) REFERENCES `OKPO` (`ID_OKPO`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `Orders` ADD CONSTRAINT `Relationship45` FOREIGN KEY (`ID_Treatie`) REFERENCES `Treaties` (`ID_Treatie`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `Goods_In_Order` ADD CONSTRAINT `Relationship49` FOREIGN KEY (`ID_OKEI`) REFERENCES `OKEI` (`ID_OKEI`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `Customer` ADD CONSTRAINT `Relationship56` FOREIGN KEY (`ID_FIAS`) REFERENCES `FIAS` (`ID_FIAS`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `Goods_In_Order` ADD CONSTRAINT `Relationship66` FOREIGN KEY (`ID_Order`) REFERENCES `Orders` (`ID_Order`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

