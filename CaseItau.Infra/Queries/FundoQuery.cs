namespace CaseItau.Infra.Queries
{
    public static class FundoQuery
    {

        public const string SelectAll = @"SELECT F.CODIGO, F.NOME, F.CNPJ, F.CODIGO_TIPO, CAST(F.PATRIMONIO AS REAL) AS PATRIMONIO, T.NOME AS NOME_TIPO 
                                          FROM FUNDO F 
                                          INNER JOIN TIPO_FUNDO T ON T.CODIGO = F.CODIGO_TIPO";

        public const string SelectId = SelectAll + " WHERE F.CODIGO = @CODIGO";

        public const string SelectValid = @"SELECT F.CODIGO, F.CNPJ 
                                            FROM FUNDO F 
                                            WHERE F.CODIGO = @CODIGO OR F.CNPJ = @CNPJ";

        public const string Insert = @"INSERT INTO FUNDO VALUES(@CODIGO, @NOME, @CNPJ, @CODIGO_TIPO, @PATRIMONIO)";

        public const string Update = @"UPDATE FUNDO 
                                       SET Nome = @NOME, CNPJ = @CNPJ, CODIGO_TIPO = @CODIGO_TIPO, PATRIMONIO = @PATRIMONIO 
                                       WHERE CODIGO = @CODIGO";

        public const string UpdatePatrimonio = @"UPDATE FUNDO 
                                                 SET PATRIMONIO = @PATRIMONIO 
                                                 WHERE CODIGO = @CODIGO";

        public const string Delete = @"DELETE FROM FUNDO WHERE CODIGO = @CODIGO";
    }
}