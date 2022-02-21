 作品名　　：Wacky
 Work Name
 作成期間　：1month+
 Time Frame

Used Engine
 - Unity 2021.2.8f1

Used Development Environment
 - Microsoft Visual Studio Community 2019 Version 16.11.9


-----------------------------------------------------------------------------------------------------
 The reason I created this program.
 プログラムを作成した理由。
-----------------------------------------------------------------------------------------------------
 Some projects I created before this project didn't use object-oriented programming ideas.
This project use inheritance and polymorphism. And use EventManager class. 
For training the most important concept in object-oriented programming.
 I spend a lot of time understanding and refactoring the code in this project.
I think this project mostly match my current skill. And want to present the most
among all projects.

　このプロジェクトの前に作成したプロジェクトは、object-oriented プログラミングのアイデアを
使用していませんでした。このプロジェクトは、inheritanceとポリモーフィズムを使用します。 
そして、EventManagerクラスを使用して、object-orientedプログラミングの最も重要な概念を
練習するためです。
　私はこのプロジェクトのコードを理解し、リファクタリングすることに多くの時間を使っていました。
このプロジェクトは私の現在のスキルとほぼ一致していると思います。
そして、すべてのプロジェクトの中で最も多くを提示したいと思います。


-----------------------------------------------------------------------------
 The important thing while creating this project
 プログラムを作成する上で注意した事
-----------------------------------------------------------------------------
 - Delegates and Event Handlers 
(I think in c++ is pointer to function / callback function and higher-order function)
 - Effect activation duration (PickupEffect enum)
SpeedupEffect does not apply to the new spawn balls.
 - DontDestroyOnLoad function in GameAudioSource class
 - Physic of the ball

-----------------------------------------------------------------------------
 What do I find difficult
 プログラムを作成する上で大変だった所
-----------------------------------------------------------------------------
 A lot because when I started this project. I still let each class know each other. 
And the most I struggle with is doing EventManager class.
 The second is fixing the bug when ball hit the bottom part of paddle(normaly on top)
or side collision of the paddle. The balls should be pushed out of the game 
but act like the hit on the top of the paddle.
 There are some bugs that I didn't fix it. It happens when the balls collide 
with each other around the center of the screen. Some balls will freeze
(Show it in video file). I could make the code to let the ball not collide 
with each other. But that is not the physic I want.

　このプロジェクトを始めたとき、私はまだ各クラスにお互いを知らせていました。
最も苦労しているのは、EventManagerクラスを作成するときです。
　2つ目は、ボールがパドルの下部（通常は上の部分）に当たったとき、またはパドルが横に
衝突したときのバグを修正することです。ボールはゲームから押し出される必要がありますが、
パドルの上部のヒットのように機能します。修正できなかったバグがあります。 
ボールが画面のスポーンポイントの周りで互いに衝突したときに発生します。
一部のボールがフリーズされます（ビデオファイルで表示）。
ボール同士がぶつからないようにコードを作ることができると思うが、
間違えるゲームプレイになります。

-----------------------------------------------------------------------------
 The particular part of this project I concentrated on
 力をいれて作った部分で、「プログラム上」で特に注意した所
-----------------------------------------------------------------------------
 EventManager class, FreezerEffect, SpeedupEffect
In paddle class, OnCollisionEnter2D function and TopCollision function
(TopCollision function fix the bug when hitting side collision)

-----------------------------------------------------------------------------------------------------
**Part of code used as starting point or didn't write on my own.
**プロジェクトの出発点か、自分で作っていなかったコード部分
-----------------------------------------------------------------------------------------------------
 I put files in the folder "Method made by other" 
These files wrote by Dr.Tim Chamillard at UCCS on Coursera. For starting point to do the project.
I use all sound file + menu sprite recieved from the course.
In-game sprites I downloaded from https://opengameart.org/content/breakout-brick-breaker-tile-set-free

 "Function made by other" 中にはCourseraのDr.TimChamillardによって作成されました。
（プロジェクトを行うための出発点として）
コースから受け取ったすべてのサウンドファイル+メニュースプライトを使用します。
https://opengameart.org/content/breakout-brick-breaker-tile-set-freeからダウンロードしたスプライト





