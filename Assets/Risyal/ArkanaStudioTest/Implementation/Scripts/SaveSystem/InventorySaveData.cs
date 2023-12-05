using Assets.KUMAGEMA.InventoryItem.Implementation.Scripts.SaveSystem;
using Assets.Risyal.ArkanaStudioTest.Core.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.SaveSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.FactorySystem;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.SaveSystem
{
    /// <summary>
    /// Untuk menyimpan data inventory.
    /// </summary>
    public class InventorySaveData : SaveData
    {
        #region Variable

        /// <summary>
        /// List item pada inventory yang disimpan.
        /// </summary>
        private List<SavedItemData> _inventoryData = new();

        /// <summary>
        /// Menangani pembuatan dari item karakter.
        /// </summary>
        private IFactory<IItem> _itemCharacterFactory = null;

        /// <summary>
        /// Menangani pembuatan dari item karakter.
        /// </summary>
        private IFactory<IItem> _itemWeaponFactory = null;

        #endregion

        #region Constructor

        public InventorySaveData(string id, ISaveManager saveManager) : base(id, saveManager)
        {
            _itemCharacterFactory = Resources.Load<ItemCharacterFactory>("So/Factory/ItemCharacterFactory");
            _itemWeaponFactory = Resources.Load<ItemWeaponFactory>("So/Factory/ItemWeaponFactory");
        }

        #endregion

        #region SaveData

        public override async UniTask Save(params object[] parameters)
        {
            _inventoryData.Clear();

            var inventory = (IInventory)parameters[0];

            foreach (var item in inventory.Items)
            {
                _inventoryData.Add(new SavedItemData()
                {
                    id = item.Id,
                    amount = item.Amount,
                    itemType = item.ItemType.ToString()
                });
            }

            await SaveManager.Save(Id, _inventoryData);
        }

        public override async UniTask Load(params object[] parameters)
        {
            _inventoryData.Clear();

            var data = await SaveManager.Load<List<SavedItemData>>(Id);

            if (data == null)
            {
                return;
            }

            foreach (var item in data)
            {
                _inventoryData.Add(item);
            }
        }

        public override void Apply(object source)
        {
            var inventory = (IInventory)source;

            foreach (var item in _inventoryData)
            {
                if (item.itemType == "Character")
                {
                    inventory.AddItem(_itemCharacterFactory.Create(item.id), item.amount);
                }
                else
                {
                    inventory.AddItem(_itemWeaponFactory.Create(item.id), item.amount);
                }
            }
        }

        public override async UniTask Delete()
        {
            SaveManager.Delete(Id);
        }

        #endregion
    }

    /// <summary>
    /// Data inventory yang di simpan.
    /// </summary>
    [Serializable]
    public struct SavedItemData
    {
        /// <summary>
        /// Id dari data.
        /// </summary>
        public string id;

        /// <summary>
        /// Jumlah object yang disimpan.
        /// </summary>
        public int amount;

        /// <summary>
        /// Tipe yang dimiliki item.
        /// </summary>
        public string itemType;
    }
}