# ShopCards - Documentation
**Version:** 1.0  
**Engine:** Unity 2022.3+

## 🚀 WebGL Build

> Access the hosted WebGL version:

- 🎮 [Itch.io](https://kidkmon.itch.io/shop-cards)

---

## 📋 Overview  
This project is a Unity project for a card shop system. It provides a modular and scalable foundation for in-game card purchases and inventory handling.
The following design patterns were used:
   - **Model-View-Controller** for separation of responsibilities in Views;
   - **Singleton** for managing global systems.


---

## 🛠️ Architectures and Patterns  
### **Singleton**  
- Used for centralized management classes:
   - `AudioManager`: Manages the audio flow of the game.    
   - `GameManager`: Controls the game flow.
   - `WalletManager`: Controls the wallet flow.
- Used for centralized system classes:
   - `CoinSystem`: Synchronizes the player's coins.  
   - `InventorySystem`: Synchronizes the player's inventory.

### **MVC (Model-View-Controller)**  
- **Model**: Data classes such as `CardAssetConfig` and `GameConfig`.  
- **View**: UI elements and animations (e.g., `CardSectionView`).  
- **Controller**: Business logic (e.g., `CardSectionViewController`).  

---

## 🎮 Main Features

- Card browsing and selection
- Purchase logic with coin balance check  
- Visual feedback for success and errors  
- Toast messages and animated popups  
- Persistent data using `PlayerPrefs`

---

## 🚀 How to Run  
1. Clone the repository.  
2. Open the project in **Unity 2022.3+**.  
3. Navigate to `Scenes/MainScene.unity`.  
4. Press **Play** in the Editor.  

---
