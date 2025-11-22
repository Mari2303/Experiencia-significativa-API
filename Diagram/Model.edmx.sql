
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/03/2025 17:20:27
-- Generated from EDMX file: C:\Users\SENA\source\repos\Mari2303\Experiencias-sig\Diagram\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Experiencia_sig];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [DeleteAt] datetime  NOT NULL,
    [CreateAt] datetime  NOT NULL
);
GO

-- Creating table 'RolSet'
CREATE TABLE [dbo].[RolSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeRol] nvarchar(max)  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [DeleteAt] datetime  NOT NULL,
    [CreateAt] datetime  NOT NULL
);
GO

-- Creating table 'Rol_Permisos'
CREATE TABLE [dbo].[Rol_Permisos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RolId] int  NOT NULL,
    [PermissionId] int  NOT NULL
);
GO

-- Creating table 'Usuario_Rols'
CREATE TABLE [dbo].[Usuario_Rols] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DeleteAt] datetime  NOT NULL,
    [CreateAt] datetime  NOT NULL,
    [UserId] int  NOT NULL,
    [RolId] int  NOT NULL
);
GO

-- Creating table 'Permisos'
CREATE TABLE [dbo].[Permisos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Permissiontype] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Historial_Experiencias'
CREATE TABLE [dbo].[Historial_Experiencias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Action] nvarchar(max)  NOT NULL,
    [DateTime] datetime  NOT NULL,
    [TableName] nvarchar(max)  NOT NULL,
    [ExperienceId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Estados'
CREATE TABLE [dbo].[Estados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [IdHistoryExperience_Id] int  NOT NULL
);
GO

-- Creating table 'Evaluacions'
CREATE TABLE [dbo].[Evaluacions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeEvaluation] nvarchar(max)  NOT NULL,
    [Comments] nvarchar(max)  NOT NULL,
    [DateTime] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL,
    [ExperienceId] int  NOT NULL,
    [IdState_Id] int  NOT NULL
);
GO

-- Creating table 'Evaluacion_Criterios'
CREATE TABLE [dbo].[Evaluacion_Criterios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Score] nvarchar(max)  NOT NULL,
    [EvaluationId] int  NOT NULL,
    [IdCriteria_Id] int  NOT NULL
);
GO

-- Creating table 'Criterios'
CREATE TABLE [dbo].[Criterios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Experiencias'
CREATE TABLE [dbo].[Experiencias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameExperiences] nvarchar(max)  NOT NULL,
    [Summary] nvarchar(max)  NOT NULL,
    [Methodologies] nvarchar(max)  NOT NULL,
    [Transfer] nvarchar(max)  NOT NULL,
    [DateRegistration] datetime  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [DeleteAt] datetime  NOT NULL,
    [CreateAt] datetime  NOT NULL,
    [UserId] int  NOT NULL,
    [InstitutionId] int  NOT NULL,
    [Idverification_Id] int  NOT NULL
);
GO

-- Creating table 'Objectivos'
CREATE TABLE [dbo].[Objectivos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ObjetiveDescription] nvarchar(max)  NOT NULL,
    [Innovation] nvarchar(max)  NOT NULL,
    [Results] nvarchar(max)  NOT NULL,
    [Sustainability] nvarchar(max)  NOT NULL,
    [ExperienceId] int  NOT NULL
);
GO

-- Creating table 'Experiencia_Grupo_Poblacionals'
CREATE TABLE [dbo].[Experiencia_Grupo_Poblacionals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExperienceId] int  NOT NULL,
    [PopulationGradeId] int  NOT NULL
);
GO

-- Creating table 'GrupoPoblacionals'
CREATE TABLE [dbo].[GrupoPoblacionals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Verificacions'
CREATE TABLE [dbo].[Verificacions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ExperienciaGrados'
CREATE TABLE [dbo].[ExperienciaGrados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GradeId] int  NOT NULL,
    [IdExperience_Id] int  NOT NULL
);
GO

-- Creating table 'Grados'
CREATE TABLE [dbo].[Grados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Institucions'
CREATE TABLE [dbo].[Institucions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [EmailInstitution] nvarchar(max)  NOT NULL,
    [Department] nvarchar(max)  NOT NULL,
    [Commune] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Documentos'
CREATE TABLE [dbo].[Documentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ExperienceId] int  NOT NULL
);
GO

-- Creating table 'ExperienciaLineaTematicas'
CREATE TABLE [dbo].[ExperienciaLineaTematicas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DeleteAt] datetime  NOT NULL,
    [CreateAt] datetime  NOT NULL,
    [LineThematicId] int  NOT NULL,
    [ExperienceId] int  NOT NULL
);
GO

-- Creating table 'LineaTematicas'
CREATE TABLE [dbo].[LineaTematicas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [DeleteAt] datetime  NOT NULL,
    [CreateAt] datetime  NOT NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [DeleteAt] datetime  NOT NULL,
    [CreateAt] datetime  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RolSet'
ALTER TABLE [dbo].[RolSet]
ADD CONSTRAINT [PK_RolSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rol_Permisos'
ALTER TABLE [dbo].[Rol_Permisos]
ADD CONSTRAINT [PK_Rol_Permisos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuario_Rols'
ALTER TABLE [dbo].[Usuario_Rols]
ADD CONSTRAINT [PK_Usuario_Rols]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Permisos'
ALTER TABLE [dbo].[Permisos]
ADD CONSTRAINT [PK_Permisos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Historial_Experiencias'
ALTER TABLE [dbo].[Historial_Experiencias]
ADD CONSTRAINT [PK_Historial_Experiencias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [PK_Estados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Evaluacions'
ALTER TABLE [dbo].[Evaluacions]
ADD CONSTRAINT [PK_Evaluacions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Evaluacion_Criterios'
ALTER TABLE [dbo].[Evaluacion_Criterios]
ADD CONSTRAINT [PK_Evaluacion_Criterios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Criterios'
ALTER TABLE [dbo].[Criterios]
ADD CONSTRAINT [PK_Criterios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Experiencias'
ALTER TABLE [dbo].[Experiencias]
ADD CONSTRAINT [PK_Experiencias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Objectivos'
ALTER TABLE [dbo].[Objectivos]
ADD CONSTRAINT [PK_Objectivos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Experiencia_Grupo_Poblacionals'
ALTER TABLE [dbo].[Experiencia_Grupo_Poblacionals]
ADD CONSTRAINT [PK_Experiencia_Grupo_Poblacionals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GrupoPoblacionals'
ALTER TABLE [dbo].[GrupoPoblacionals]
ADD CONSTRAINT [PK_GrupoPoblacionals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Verificacions'
ALTER TABLE [dbo].[Verificacions]
ADD CONSTRAINT [PK_Verificacions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExperienciaGrados'
ALTER TABLE [dbo].[ExperienciaGrados]
ADD CONSTRAINT [PK_ExperienciaGrados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Grados'
ALTER TABLE [dbo].[Grados]
ADD CONSTRAINT [PK_Grados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Institucions'
ALTER TABLE [dbo].[Institucions]
ADD CONSTRAINT [PK_Institucions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documentos'
ALTER TABLE [dbo].[Documentos]
ADD CONSTRAINT [PK_Documentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExperienciaLineaTematicas'
ALTER TABLE [dbo].[ExperienciaLineaTematicas]
ADD CONSTRAINT [PK_ExperienciaLineaTematicas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LineaTematicas'
ALTER TABLE [dbo].[LineaTematicas]
ADD CONSTRAINT [PK_LineaTematicas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdHistoryExperience_Id] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [FK_EstadoHistorial_Experiencia]
    FOREIGN KEY ([IdHistoryExperience_Id])
    REFERENCES [dbo].[Historial_Experiencias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoHistorial_Experiencia'
CREATE INDEX [IX_FK_EstadoHistorial_Experiencia]
ON [dbo].[Estados]
    ([IdHistoryExperience_Id]);
GO

-- Creating foreign key on [IdState_Id] in table 'Evaluacions'
ALTER TABLE [dbo].[Evaluacions]
ADD CONSTRAINT [FK_EvaluacionEstado]
    FOREIGN KEY ([IdState_Id])
    REFERENCES [dbo].[Estados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EvaluacionEstado'
CREATE INDEX [IX_FK_EvaluacionEstado]
ON [dbo].[Evaluacions]
    ([IdState_Id]);
GO

-- Creating foreign key on [EvaluationId] in table 'Evaluacion_Criterios'
ALTER TABLE [dbo].[Evaluacion_Criterios]
ADD CONSTRAINT [FK_EvaluacionEvaluacion_Criterio]
    FOREIGN KEY ([EvaluationId])
    REFERENCES [dbo].[Evaluacions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EvaluacionEvaluacion_Criterio'
CREATE INDEX [IX_FK_EvaluacionEvaluacion_Criterio]
ON [dbo].[Evaluacion_Criterios]
    ([EvaluationId]);
GO

-- Creating foreign key on [IdCriteria_Id] in table 'Evaluacion_Criterios'
ALTER TABLE [dbo].[Evaluacion_Criterios]
ADD CONSTRAINT [FK_Evaluacion_CriterioCriterio]
    FOREIGN KEY ([IdCriteria_Id])
    REFERENCES [dbo].[Criterios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Evaluacion_CriterioCriterio'
CREATE INDEX [IX_FK_Evaluacion_CriterioCriterio]
ON [dbo].[Evaluacion_Criterios]
    ([IdCriteria_Id]);
GO

-- Creating foreign key on [Idverification_Id] in table 'Experiencias'
ALTER TABLE [dbo].[Experiencias]
ADD CONSTRAINT [FK_ExperienciaVerificacion]
    FOREIGN KEY ([Idverification_Id])
    REFERENCES [dbo].[Verificacions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienciaVerificacion'
CREATE INDEX [IX_FK_ExperienciaVerificacion]
ON [dbo].[Experiencias]
    ([Idverification_Id]);
GO

-- Creating foreign key on [IdExperience_Id] in table 'ExperienciaGrados'
ALTER TABLE [dbo].[ExperienciaGrados]
ADD CONSTRAINT [FK_ExperienciaGradoExperiencia]
    FOREIGN KEY ([IdExperience_Id])
    REFERENCES [dbo].[Experiencias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienciaGradoExperiencia'
CREATE INDEX [IX_FK_ExperienciaGradoExperiencia]
ON [dbo].[ExperienciaGrados]
    ([IdExperience_Id]);
GO

-- Creating foreign key on [UserId] in table 'Experiencias'
ALTER TABLE [dbo].[Experiencias]
ADD CONSTRAINT [FK_UserExperience]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserExperience'
CREATE INDEX [IX_FK_UserExperience]
ON [dbo].[Experiencias]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Usuario_Rols'
ALTER TABLE [dbo].[Usuario_Rols]
ADD CONSTRAINT [FK_UserUserRol]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserRol'
CREATE INDEX [IX_FK_UserUserRol]
ON [dbo].[Usuario_Rols]
    ([UserId]);
GO

-- Creating foreign key on [RolId] in table 'Usuario_Rols'
ALTER TABLE [dbo].[Usuario_Rols]
ADD CONSTRAINT [FK_UserRolRol]
    FOREIGN KEY ([RolId])
    REFERENCES [dbo].[RolSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRolRol'
CREATE INDEX [IX_FK_UserRolRol]
ON [dbo].[Usuario_Rols]
    ([RolId]);
GO

-- Creating foreign key on [RolId] in table 'Rol_Permisos'
ALTER TABLE [dbo].[Rol_Permisos]
ADD CONSTRAINT [FK_RolRolPermission]
    FOREIGN KEY ([RolId])
    REFERENCES [dbo].[RolSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolRolPermission'
CREATE INDEX [IX_FK_RolRolPermission]
ON [dbo].[Rol_Permisos]
    ([RolId]);
GO

-- Creating foreign key on [PermissionId] in table 'Rol_Permisos'
ALTER TABLE [dbo].[Rol_Permisos]
ADD CONSTRAINT [FK_PermissionRolPermission]
    FOREIGN KEY ([PermissionId])
    REFERENCES [dbo].[Permisos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PermissionRolPermission'
CREATE INDEX [IX_FK_PermissionRolPermission]
ON [dbo].[Rol_Permisos]
    ([PermissionId]);
GO

-- Creating foreign key on [UserId] in table 'Evaluacions'
ALTER TABLE [dbo].[Evaluacions]
ADD CONSTRAINT [FK_UserEvaluation]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEvaluation'
CREATE INDEX [IX_FK_UserEvaluation]
ON [dbo].[Evaluacions]
    ([UserId]);
GO

-- Creating foreign key on [ExperienceId] in table 'Evaluacions'
ALTER TABLE [dbo].[Evaluacions]
ADD CONSTRAINT [FK_ExperienceEvaluation]
    FOREIGN KEY ([ExperienceId])
    REFERENCES [dbo].[Experiencias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienceEvaluation'
CREATE INDEX [IX_FK_ExperienceEvaluation]
ON [dbo].[Evaluacions]
    ([ExperienceId]);
GO

-- Creating foreign key on [GradeId] in table 'ExperienciaGrados'
ALTER TABLE [dbo].[ExperienciaGrados]
ADD CONSTRAINT [FK_GradeExperienceGrade]
    FOREIGN KEY ([GradeId])
    REFERENCES [dbo].[Grados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradeExperienceGrade'
CREATE INDEX [IX_FK_GradeExperienceGrade]
ON [dbo].[ExperienciaGrados]
    ([GradeId]);
GO

-- Creating foreign key on [ExperienceId] in table 'Objectivos'
ALTER TABLE [dbo].[Objectivos]
ADD CONSTRAINT [FK_ExperienceObjective]
    FOREIGN KEY ([ExperienceId])
    REFERENCES [dbo].[Experiencias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienceObjective'
CREATE INDEX [IX_FK_ExperienceObjective]
ON [dbo].[Objectivos]
    ([ExperienceId]);
GO

-- Creating foreign key on [LineThematicId] in table 'ExperienciaLineaTematicas'
ALTER TABLE [dbo].[ExperienciaLineaTematicas]
ADD CONSTRAINT [FK_ExperienceLineThematicLineThematic]
    FOREIGN KEY ([LineThematicId])
    REFERENCES [dbo].[LineaTematicas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienceLineThematicLineThematic'
CREATE INDEX [IX_FK_ExperienceLineThematicLineThematic]
ON [dbo].[ExperienciaLineaTematicas]
    ([LineThematicId]);
GO

-- Creating foreign key on [ExperienceId] in table 'Historial_Experiencias'
ALTER TABLE [dbo].[Historial_Experiencias]
ADD CONSTRAINT [FK_HistoryExperienceExperience]
    FOREIGN KEY ([ExperienceId])
    REFERENCES [dbo].[Experiencias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HistoryExperienceExperience'
CREATE INDEX [IX_FK_HistoryExperienceExperience]
ON [dbo].[Historial_Experiencias]
    ([ExperienceId]);
GO

-- Creating foreign key on [ExperienceId] in table 'Documentos'
ALTER TABLE [dbo].[Documentos]
ADD CONSTRAINT [FK_ExperienceDocument]
    FOREIGN KEY ([ExperienceId])
    REFERENCES [dbo].[Experiencias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienceDocument'
CREATE INDEX [IX_FK_ExperienceDocument]
ON [dbo].[Documentos]
    ([ExperienceId]);
GO

-- Creating foreign key on [ExperienceId] in table 'ExperienciaLineaTematicas'
ALTER TABLE [dbo].[ExperienciaLineaTematicas]
ADD CONSTRAINT [FK_ExperienceExperienceLineThematic]
    FOREIGN KEY ([ExperienceId])
    REFERENCES [dbo].[Experiencias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienceExperienceLineThematic'
CREATE INDEX [IX_FK_ExperienceExperienceLineThematic]
ON [dbo].[ExperienciaLineaTematicas]
    ([ExperienceId]);
GO

-- Creating foreign key on [ExperienceId] in table 'Experiencia_Grupo_Poblacionals'
ALTER TABLE [dbo].[Experiencia_Grupo_Poblacionals]
ADD CONSTRAINT [FK_ExperienceExperiencePopulationGroup]
    FOREIGN KEY ([ExperienceId])
    REFERENCES [dbo].[Experiencias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienceExperiencePopulationGroup'
CREATE INDEX [IX_FK_ExperienceExperiencePopulationGroup]
ON [dbo].[Experiencia_Grupo_Poblacionals]
    ([ExperienceId]);
GO

-- Creating foreign key on [PopulationGradeId] in table 'Experiencia_Grupo_Poblacionals'
ALTER TABLE [dbo].[Experiencia_Grupo_Poblacionals]
ADD CONSTRAINT [FK_PopulationGradeExperiencePopulationGroup]
    FOREIGN KEY ([PopulationGradeId])
    REFERENCES [dbo].[GrupoPoblacionals]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PopulationGradeExperiencePopulationGroup'
CREATE INDEX [IX_FK_PopulationGradeExperiencePopulationGroup]
ON [dbo].[Experiencia_Grupo_Poblacionals]
    ([PopulationGradeId]);
GO

-- Creating foreign key on [InstitutionId] in table 'Experiencias'
ALTER TABLE [dbo].[Experiencias]
ADD CONSTRAINT [FK_InstitutionExperience]
    FOREIGN KEY ([InstitutionId])
    REFERENCES [dbo].[Institucions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstitutionExperience'
CREATE INDEX [IX_FK_InstitutionExperience]
ON [dbo].[Experiencias]
    ([InstitutionId]);
GO

-- Creating foreign key on [User_Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [FK_PersonUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonUser'
CREATE INDEX [IX_FK_PersonUser]
ON [dbo].[PersonSet]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'Historial_Experiencias'
ALTER TABLE [dbo].[Historial_Experiencias]
ADD CONSTRAINT [FK_UserHistoryExperience]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserHistoryExperience'
CREATE INDEX [IX_FK_UserHistoryExperience]
ON [dbo].[Historial_Experiencias]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------