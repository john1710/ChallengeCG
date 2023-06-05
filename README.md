# ChallengeCG

# O Projeto Consiste em:
- asp net web api 6
- asp net mvc 6
- test xunit

# como base de dados foi utilizado um container docker do sql server, configurações de conexões podem ser alteradas no app settings.


#Há uma branch chamada Docker-setup onde possui um compose para startar ambos os projetos, antes é necessario criar uma base de dados sqlserver e passar a connectionstring como uma variavel de ambiente chamada "ChallengeDB" para os projetos/serviços: [api e migrations]
