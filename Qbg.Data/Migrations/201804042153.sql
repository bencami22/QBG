  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
__EFMigrationsHistory' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

CREATE TABLE `Roles` (
    `Id` bigint NOT NULL,
    `Description` varchar(100) NULL,
    `Name` varchar(100) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Users` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `DateCreated` datetime NOT NULL DEFAULT '2018-04-04 19:24:56.654',
    `Email` text NULL,
    `Password` text NOT NULL,
    `Username` varchar(50) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `UserRole` (
    `UserId` bigint NOT NULL,
    `RoleId` bigint NOT NULL,
    PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `AK_UserRole_RoleId_UserId` UNIQUE (`RoleId`, `UserId`),
    CONSTRAINT `FK_UserRole_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_UserRole_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180404192456_InitialCreate', '2.0.2-rtm-10011');

