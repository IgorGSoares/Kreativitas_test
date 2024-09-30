# Kreativitas_test

Versão da Unity: 2022.3.28f

Branch atual: wave

Link Trello: https://trello.com/invite/b/66f735833076887d8b0eed69/ATTI5b0f7e86afe5821f61f482546d2017289AEE1C3D/kreativitas-test

Link Build: https://drive.google.com/drive/folders/1gt3CkH6svmnQS0QGv9-GWTjKDulpaHjL?usp=sharing

Início da produção: 27/09/2024 -> 19:30

Após jogar o jogo por uma hora, o projeto base foi feito, juntamente com este repositório e a inclusão de assets que geralmente costumo usar em meus projetos (DOTween, Cinemachine, Joystick Pack, e RiderFlow JetBrains). Devido à escassez de tempo e complexidade, o asset Input System foi cogitado, mas não utilizado. A criação de classes principais como GameManager e GlocabActions não apresentaram dificuldade, porém a classe responsável por gerenciar o movimento do jogador apresentou pequena dificuldade devido ao uso inicial de física para movimentar. Logo a ideia foi descartada e optou-se por uma movimentação simples, mais tarde utilizando-se de limites no lugar de colisores invisíveis. O uso de um joystick para o mesmo foi uma alternativa para o uso do Input System e como uma alternativa mais simples e rápida.

Uma classe de polling foi desenvolvida de forma que pudesse ser usada tanto para os tiros quanto para as moedas, e por ser algo que lido há um certo tempo, não houve grandes dificuldades neste ponto. As pedras que caem por outro lado, devido a sua complexidade, custaram muito tempo para serem implementados. O uso de herança já se era imaginado, mas a quantidade de fatores relacionados a eles, o uso de física para se movimentarem, colisões, bugs relacionados à movimentação e escala foram apenas algumas das dificuldades enfrentadas para o desenvolvimento do projeto, que com tempo e esforço, foram devidamente resolvidos. Outros bugs, como a colisão das moedas influenciar a movimentação do jogador e o mesmo ignorando as paredes invisíveis ocorreram, mas também foram solucionados.

Durante o desenvolvimento, buscou-se separar as classes devidamente por suas funções e utilizar meios que otimizassem o jogo, como colisores em forma de círculo e cápsula, pooling, usar em poucos momentos o método GetComponent<>, uma classe de Actions, o jogo ser feito em uma única tela (algo que eu já havia feito durante uma GameJam Solidária e me deu o conhecimento necessário para o fazer outra vez), etc. A UI foi desenvolvida de forma simples, porém visando ser compatível com dispositivos móveis e que comportasse futuras atualizações (sobretudo uma futura tela de loja, upgrade, e troca de canhões). Um sistema simples de spawn das pedras foi desenvolvido, e posteriormente refeito para atuar como um sistema de ondas. Parte do código precisou ser repensado, mas não totalmente descartado, já que a base para spawná-los em tela foi reaproveitado nas ondas.

Infelizmente devido à escassez de tempo e complexidade, houveram elementos que foram pensados, mas que não puderam ser implementados, sendo eles:

  -Chefão;

  -Power ups e pedras que os spawnam;

  -Sistema de upgrade;

  -Loja de pontos e de canhões;

  -Mais informações na UI;

  -Sistema de Save (este último não era complexo, mas outros fatores mais importantes como as pedras e o sistema de spawn delas se provaram mais importantes).


Todavia, agradeço pela experiência, foi bom desenvolver o projeto e aprendi muito com esta experiência. Caso algum dos elementos que foram desenvolvidos poderiam ter sido executados de uma forma melhor, gostaria de saber para assim melhorar profissionalmente. 

Att.
Igor Gilberto Soares
