IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Groups] (
    [GroupId] int NOT NULL IDENTITY,
    [GroupLabel] nvarchar(max) NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY ([GroupId])
);

CREATE TABLE [Kits] (
    [KitId] int NOT NULL IDENTITY,
    [KitName] nvarchar(max) NULL,
    CONSTRAINT [PK_Kits] PRIMARY KEY ([KitId])
);

CREATE TABLE [Roles] (
    [RoleId] int NOT NULL IDENTITY,
    [RoleName] nvarchar(max) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleId])
);

CREATE TABLE [Courses] (
    [CourseId] int NOT NULL IDENTITY,
    [CourseName] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [KitId] int NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([CourseId]),
    CONSTRAINT [FK_Courses_Kits_KitId] FOREIGN KEY ([KitId]) REFERENCES [Kits] ([KitId])
);

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [RoleId] int NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]),
    CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([RoleId])
);

CREATE TABLE [CourseGroups] (
    [CourseGroupId] int NOT NULL IDENTITY,
    [CourseId] int NULL,
    [GroupId] int NULL,
    [TeacherId] int NULL,
    CONSTRAINT [PK_CourseGroups] PRIMARY KEY ([CourseGroupId]),
    CONSTRAINT [FK_CourseGroups_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([CourseId]),
    CONSTRAINT [FK_CourseGroups_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([GroupId]),
    CONSTRAINT [FK_CourseGroups_Users_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [Users] ([UserId])
);

CREATE TABLE [CourseUsers] (
    [CourseUserId] int NOT NULL IDENTITY,
    [CourseId] int NULL,
    [UserId] int NULL,
    CONSTRAINT [PK_CourseUsers] PRIMARY KEY ([CourseUserId]),
    CONSTRAINT [FK_CourseUsers_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([CourseId]),
    CONSTRAINT [FK_CourseUsers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId])
);

CREATE INDEX [IX_CourseGroups_CourseId] ON [CourseGroups] ([CourseId]);

CREATE INDEX [IX_CourseGroups_GroupId] ON [CourseGroups] ([GroupId]);

CREATE INDEX [IX_CourseGroups_TeacherId] ON [CourseGroups] ([TeacherId]);

CREATE INDEX [IX_Courses_KitId] ON [Courses] ([KitId]);

CREATE INDEX [IX_CourseUsers_CourseId] ON [CourseUsers] ([CourseId]);

CREATE INDEX [IX_CourseUsers_UserId] ON [CourseUsers] ([UserId]);

CREATE INDEX [IX_Users_RoleId] ON [Users] ([RoleId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250310064454_InitialCreate', N'9.0.2');

COMMIT;
GO