# 初めに
このリポジトリでは、架空のペルソナを設定し、そのペルソナが望むプロダクトや機能を想定して作成したものをまとめています。  
ペルソナのニーズに基づいたデザインや機能の考え方を示すことを目的としています。
# アプリのコンセプト 

オリーブショップの店員向けに、受注・商品管理・購入分析を行える業務支援アプリのプロトタイプです。  
毎日の作業を楽しく行えるよう、オリーブをモチーフにしたデザインを採用しています。

> 💡 本アプリは主にUI設計とデザインコンセプトを目的としており、  
> 一部機能（受注の視覚化）以外は未実装です。

>アプリのインストーラー[インストーラー](setolive-ui-design/setolive-ui-design/セトリーブインストーラー.exe)

---

## 👤 ペルソナ
**名前**：田中みどり（28歳）  
**職業**：オリーブショップ店長  
**課題**：
- 受注管理が複雑
- 在庫状況を確認するのに毎回別システムを開く必要がある  
- 売上分析をできていない
- 楽しく仕事をしたい

**ニーズ**：
- ひと目で受注状況を確認したい  
- シンプルで使いやすい操作画面がほしい  
- 日々の成果を楽しく把握したい  

---

## 🌿 デザイン（GitHub上）
- アプリの画面イメージをGitHub上で確認できます
<img src="setolive-ui-design/setolive-ui-design/images/スクリーンショット 2025-10-26 123410.png" alt="ログイン画面" width="50%">
- 受注作業を行う画面
<img src="setolive-ui-design/setolive-ui-design/images/スクリーンショット%202025-10-26%20123151.png" alt="ダッシュボード画面" width="50%">
<img src="setolive-ui-design/setolive-ui-design/images/スクリーンショット 2025-10-26 123159.png" alt="商品詳細画面" width="50%">
<img src="setolive-ui-design/setolive-ui-design/images/スクリーンショット 2025-10-26 123300.png" alt="分析画面" width="50%">


詳細は
- 要件定義書
- アプリケーション仕様書　参照
- アプリのインストール
---

## 📊 設計資料（Google Drive）
- [要件定義書（PDF）](setolive-ui-design/setolive-ui-design/要件定義修正.md)  
- [画面遷移図（draw.io PNG）](setolive-ui-design/setolive-ui-design/images/画面遷移図ファイル%20(2).drawio.png)  
- [ユースケース図（draw.io PNG）](setolive-ui-design/setolive-ui-design/images/ユースケース図ファイル.drawio.png)  
- [ER図（draw.io PNG）](setolive-ui-design/setolive-ui-design/images/ER図ファイル.drawio.png)
- [アプリ仕様書受注画面（draw.io PNG）](setolive-ui-design/setolive-ui-design/images/アプリ仕様書受注画面(3)-ページ1.drawio.png)
- [アプリ仕様書商品画面（draw.io PNG）](setolive-ui-design/setolive-ui-design/images/アプリ仕様書syou-ページ4.drawio.png)
- [アプリ仕様書分析画面（draw.io PNG）](setolive-ui-design/setolive-ui-design/images/アプリ仕様書分析(3)-ページ5.drawio.png)
- [アプリ仕様書使い方（draw.io PNG）](setolive-ui-design/setolive-ui-design/images/アプリ仕様書使い方-ページ6.drawio.png)
> 💡 設計資料は、draw.ioで作成したものをPNGで保存しています

---

## 🧩 機能構想

| 機能名 | 概要 | 実装状況 |
|--------|------|-----------|
| 受注の視覚化 | 受注カードを一覧表示し、状態を色分けして管理 | ✅ 試作済み |
| 商品管理 | 商品情報の登録・編集・削除機能 | 🔸 未実装 |
| 購入分析 | 売上や購入データの可視化（グラフ表示） | 🔸 未実装 |

---

## ⚙️ 開発環境
- 言語：C#  
- フレームワーク：Windows Forms  
- IDE：Visual Studio 2022  
- 対象OS：Windows 10 / 11  

---

## 🪴 開発の目的
店舗業務を「早く・正確に・楽しく」する。  
売り上げ分析を行うことで売り上げ上昇を行う

---



