# ProjetosAula
O sistema deve permitir, minimamente, os seguintes casos de uso por parte de usuários logados:
 Anunciar um item para venda. Um item para venda deve ter um título, uma imagem (ou um
conjunto de imagens), descrição do produto, um valor de venda, local (cidade gaúcha ou
bairro Porto-Alegrense) e estar associado a uma das categorias disponibilizadas pelo
sistema.
 Responder questionamentos de outros usuários (a resposta pode incluir uma imagem).
 Enviar pedidos de informações (questionamentos) sobre itens colocados à venda por outros
usuários.
 Solicitar compra de produtos (o vendedor é notificado e o produto passa para situação “em
negociação” até que o vendedor confirme a venda ou desista do negócio).
 Realizar avaliação de uma compra (após o vendedor confirmar a venda o comprador é
notificado que deve realizar a avaliação do negócio. Os critérios de avaliação devem ser
definidos por cada grupo e utilizados para definir uma reputação para o vendedor).
 Bloquear o anúncio, caso tenha desistido da venda ou tenha “fechado negócio”, após
bloqueado um anuncio não recebe mais questionamentos nem respostas.
 Responder notificações de pedidos de compra por parte de outros usuários ou sugestões
de envio para doação dado o tempo que o produto está disponível para venda.
O sistema deve permitir os seguintes casos de uso por parte de todos usuários:
 Criar conta e logar no sistema.
 Realizar pesquisas. O sistema deve oferecer várias formas de pesquisa, como por exemplo:
por categoria, por faixa de preço, vendedor, por palavras chave no título ou descrição.
Outras pesquisas e a composição destas são um diferencial competitivo.
 Visualizar detalhes de uma oferta, que inclui todas os questionamentos e respostas
relacionadas ao item, avaliação da venda, se for o caso, reputação do vendedor e outras
informações que o grupo julgar pertinente.
o A reputação do vendedor é calculada a partir das avaliações por parte dos
compradores (no caso de fechar negócio ou desistência), relação entre produtos
anunciados e vendidos (itens enviados para doação valorizam o vendedor e
desistências penalizam a reputação), relação entre perguntas e respostas, etc.
O sistema deve possuir também um módulo gerencial que permita obter as seguintes
informações relativas ao uso do sistema:
 Número de itens: anunciados, bloqueados por término da validade da oferta, por desistência
do vendedor ou por venda;
 Visualizar detalhes de um vendedor, informado número de itens colocados à venda,
questionamentos realizados, respostas emitidas, produtos vendidos, valor total de produtos
ofertados/vendidos, reputação, etc.
 Outros relatórios, como por exemplo os relatórios acima por períodos, ou que o grupo julgar
de interesse da aplicação, são um diferencial competitivo.
 Criar novas categorias. Uma categoria é composta por um título e uma descrição.
 Diariamente o gerente dispara um processo de verificação dos produtos disponíveis,
bloqueando para doação aqueles que foram ofertados a 60 ou mais dias e não vendidos e
nem marcados com a desistência do negócio por parte do vendedor.
Atenção!
1. Pelo menos as seguintes contas devem ser criadas e habilitadas para testes e avaliação do
sistema:
 conta de administração - usuário: admin@s2b.br, senha: s2b
 outros usuários – hugo@s2b.br, ze@s2b.br e luis@s2b.br, todos com senha s2b
2. Para a apresentação do projeto cadastre antecipadamente um número razoável de dados que
permitam avaliar as funcionalidades desenvolvidas e os relatórios gerados.
