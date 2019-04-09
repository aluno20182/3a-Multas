CREATE TABLE [dbo].[Multas] (
    [ID]           INT             IDENTITY (1, 1) NOT NULL,
    [Infracao]     NVARCHAR (MAX)  NULL,
    [LocalDaMulta] NVARCHAR (MAX)  NULL,
    [ValorMulta]   DECIMAL (18, 2) NOT NULL,
    [DataDaMulta]  DATETIME        NOT NULL,
    [ViaturaFK]    INT             DEFAULT ((0)) NOT NULL,
    [AgenteFK]     INT             DEFAULT ((0)) NOT NULL,
    [Multas_ID]    INT             NULL,
    [CondutorFK]   INT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.Multas] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Multas_dbo.Agentes_AgenteFK] FOREIGN KEY ([AgenteFK]) REFERENCES [dbo].[Agentes] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Multas_dbo.Multas_Multas_ID] FOREIGN KEY ([Multas_ID]) REFERENCES [dbo].[Multas] ([ID]),
    CONSTRAINT [FK_dbo.Multas_dbo.Viaturas_ViaturaFK] FOREIGN KEY ([ViaturaFK]) REFERENCES [dbo].[Viaturas] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Multas_dbo.Condutores_CondutorFK] FOREIGN KEY ([CondutorFK]) REFERENCES [dbo].[Condutores] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ViaturaFK]
    ON [dbo].[Multas]([ViaturaFK] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AgenteFK]
    ON [dbo].[Multas]([AgenteFK] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Multas_ID]
    ON [dbo].[Multas]([Multas_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CondutorFK]
    ON [dbo].[Multas]([CondutorFK] ASC);

