#  精密零件資產管理系統

## 專案簡介
本專案是一款專為製造業精密設備（如線性馬達、工業導軌）設計的 **數位化資產管理與維修預測系統**。

傳統製造業往往僅以「時間」作為零件報廢基準，本系統透過 C# 與 WPF 開發，導入財務會計中的 **「工作量法 (Units-of-production method)」**。系統會根據硬體實際運作的里程數據，動態計算零件的 **帳面價值 (Book Value)** 與 **健康狀態**，幫助企業更精準地規劃維修預算與資本支出 (CAPEX)。

---

##  核心功能
*   **動態折舊核算**：捨棄傳統直線折舊，改採工業規格書里程比例進行資產攤提。
*   **即時互動監控**：實作 `INotifyPropertyChanged` 雙向綁定技術，當累積里程數據變動時，剩餘價值與健康狀態會即時跳動更新。
*   **預防性維護警報**：系統自動根據消耗比例判斷狀態（ 良好 /  安排保養 /  建議更換）。
*   **財務報表匯出**：內建 CSV 匯出功能，將技術數據無縫對接到財務部門的 Excel 報表中進行二次分析。

---

##  技術棧
*   **Language**: C# (.NET 8)
*   **Framework**: WPF (Windows Presentation Foundation)
*   **Design Pattern**: MVVM (Model-View-ViewModel)
*   **Features**: Data Binding, File I/O (CSV), Interface implementation (`INotifyPropertyChanged`)

---

##  跨領域亮點
本專案具備 **「財務會計背景」** 與 **「軟體開發能力」** 的跨界整合：
1.  **會計專業應用**：將抽象的財務價值（殘值計算）與具體的硬體壽命數據結合。
2.  **數據敏感度**：理解企業在設備維護上的財務痛點，提供具備商業價值的軟體解決方案。

---

##  介面展示
<p align="center">
  <img src="https://github.com/user-attachments/assets/ebec8ad8-c532-4f51-beb4-f8dea4a573f5" width="850" alt="精密零件資產管理系統介面">
  <br>
  <strong>圖：系統實作畫面 - 即時里程追蹤與財務價值動態核算</strong>
</p>

---

##  如何運行
1.  複製此儲存庫。
2.  使用 **Visual Studio 2022** 開啟 `.sln` 檔案。
3.  按 `F5` 建置並執行專案。
4.  在 **「累積里程」** 欄位直接輸入數字，觀測資產價值之即時變動。

本作品僅供技術展示使用，所有數據均為模擬生成。
