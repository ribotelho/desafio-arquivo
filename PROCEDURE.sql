CREATE PROCEDURE prc_BuscaTransacoes @Data DATE
As  
BEGIN
	  
	  SELECT cartao, valor, data FROM Transacoes WITH (NOLOCK)
	  WHERE data = @Data
END



