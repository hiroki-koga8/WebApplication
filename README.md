# リポジトリの説明
Razor Pagesを用いてWEBアプリケーションを学習するためのリポジトリです。
業務用のタスク管理が行えるWEBアプリケーションの作成を行っています。

# 説明
## タスク一覧画面

* DBに登録されているタスク一覧を表示することができます。
### 表示項目
* 登録されているタスクの一覧

### 画面操作時の挙動
* タスク登録リンクをクリック
   * タスク登録画面へ遷移する
 
* 編集リンクをクリック
   * 編集リンクが表示されているタスクのタスク編集画面へ遷移する
 
### TODO(今後実施したいこと)
* cssでスタイルを整える
* 各項目ごとの絞り込み（開始日、終了日が〇月分だけ表示、状態が「完了」のものだけ表示など）
* 表示してある一覧をExcelやcsvで出力する機能
----
## タスク登録画面
* DBにタスクを登録することができます。
### 表示項目
* 名称
  * タスクの名称を入力することができるフィールド
  * 入力必須 
* 開始日
  * タスクの開始日を入力することができるフィールド
  * 入力必須
* 終了日
  * タスクの開始日を入力することができるフィールド
* 内容
　* タスクの内容を入力することができるフィールド
* 状態
　* タスクの状態を選択することができるプルダウン
  * 「未対応」「対応中」「完了」が選択可能
* 予定工数
  * タスクの予定工数を入力することができるフィールド
  * 入力必須
* 実績工数
  * タスクの実績工数を入力することができるフィールド
* 予実の乖離値
  * タスクの予定工数、実績工数の乖離値を入力することができるフィールド
* 備考
  * 備考を入力することができるフィールド 

### 画面操作時の挙動
* 「一覧へ戻る」リンクをクリック
  * タスク一覧画面へ遷移する
* 登録ボタンをクリック
  * 入力必須の項目を入力していない場合
    * 画面遷移せずエラーが表示
  * 入力必須の項目が入力されている場合
    * 入力した内容がDBに登録される
    * タスク一覧画面へ遷移する
   
### TODO(今後実施したいこと)
* cssでスタイルを整える
* 予実の乖離値はアプリ側で計算するようにしたい
* 入力必須の項目を入力していない場合のエラーメッセージをデフォルトから変更
---- 
## タスク編集画面

* DBに登録されているタスクを編集することができます。
### 表示項目
* タスク登録画面とほぼ同じ
* フィールドなどは対象のタスクのデータが表示される

### 画面操作時の挙動
* 「一覧へ戻る」リンクをクリック
  * タスク一覧画面へ遷移する
* 削除ボタンをクリック
  * タスクが削除される
  * タスク一覧画面へ遷移する
* 保存ボタンをクリック
  * 入力必須の項目を入力していない場合
    * 画面遷移せずエラーが表示
    * ![image](https://github.com/user-attachments/assets/5de44884-ae50-4bf3-b717-b9e0cfddf1bf)
  * 入力必須の項目が入力されている場合
    * 入力した内容がDBに保存される
    * タスク一覧画面へ遷移する
   
### TODO(今後実施したいこと)
* cssでスタイルを整える
* 削除時に確認のダイアログを表示できるようにしたい
* 予実の乖離値はアプリ側で計算するようにしたい
* 入力必須の項目を入力していない場合のエラーメッセージをデフォルトから変更

### 動かし方
1.`bin/Debug/net8.0/WebApplicationTest.exe` を起動
2.コンソールに表示されているlocalhostのURLを開く

#### 参考）
* https://learn.microsoft.com/ja-jp/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-9.0&tabs=visual-studio
* https://qiita.com/shironana/items/18d38933324a3e4276ee
* https://qiita.com/te-k/items/0fb0adadf00e264f4c0b
