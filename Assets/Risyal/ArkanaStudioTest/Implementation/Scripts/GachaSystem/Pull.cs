using Assets.Risyal.ArkanaStudioTest.Core.ContainerSystem;
using Assets.Risyal.ArkanaStudioTest.Core.Data;
using Assets.Risyal.ArkanaStudioTest.Core.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using Sirenix.OdinInspector;
using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.MainGamePlay
{
    /// <summary>
    /// Implementasi IPull, untuk pull karakter.
    /// </summary>
    public class Pull : MonoBehaviour, IPull
    {
        #region Variable

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPityData _pityData = null;

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPool<CharacterData> _characterPool = null;

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPool<WeaponData> _weaponPool = null;

        /// <summary>
        /// Menyimpan sejarah pull player.
        /// </summary>
        private IListContainer<string> _pullHistory = null;

        /// <summary>
        /// Menangani inventory yang dimiliki oleh player.
        /// </summary>
        private IInventory _inventory = null;

        /// <summary>
        /// Menangani pembuatan dari item karakter.
        /// </summary>
        private IFactory<IItem> _itemCharacterFactory = null;

        /// <summary>
        /// Menangani pembuatan dari item karakter.
        /// </summary>
        private IFactory<IItem> _itemWeaponFactory = null;

        #endregion

        #region Main

        /// <summary>
        /// Untuk mendapatkan karakter dengan rarity super rare.
        /// </summary>
        /// <returns>
        /// Mengembalikan nilai berupa CharacterData.
        /// </returns>
        private CharacterData GetCharacterSuperRare()
        {
            var characters = _characterPool.Pool.Where(x => x.template.Rarity == Core.Template.CharacterRarity.SuperRare).ToList();

            var characterData = characters[Random.Range(0, characters.Count)];

            return characterData;
        }

        /// <summary>
        /// Untuk mendapatkan weapon dengan rarity super rare.
        /// </summary>
        /// <returns>
        /// Mengembalikan nilai berupa WeaponData.
        /// </returns>
        private WeaponData GetWeaponSuperRare()
        {
            var weapons = _weaponPool.Pool.Where(x => x.template.Rarity == Core.Template.WeaponRarity.SuperRare).ToList();

            var weaponData = weapons[Random.Range(0, weapons.Count)];

            return weaponData;
        }

        /// <summary>
        /// Untuk mendapatkan karakter dengan rarity rare.
        /// </summary>
        /// <returns>
        /// Mengembalikan nilai berupa CharacterData.
        /// </returns>
        private CharacterData GetCharacterRare()
        {
            var characters = _characterPool.Pool.Where(x => x.template.Rarity == Core.Template.CharacterRarity.Rare).ToList();

            var characterData = characters[Random.Range(0, characters.Count)];

            return characterData;
        }

        /// <summary>
        /// Untuk mendapatkan weapon dengan rarity rare.
        /// </summary>
        /// <returns>
        /// Mengembalikan nilai berupa WeaponData.
        /// </returns>
        private WeaponData GetWeaponRare()
        {
            var weapons = _weaponPool.Pool.Where(x => x.template.Rarity == Core.Template.WeaponRarity.Rare).ToList();

            var weaponData = weapons[Random.Range(0, weapons.Count)];

            return weaponData;
        }

        /// <summary>
        /// Untuk mendapatkan weapon dengan rarity normal.
        /// </summary>
        /// <returns>
        /// Mengembalikan nilai berupa WeaponData.
        /// </returns>
        private WeaponData GetWeaponNormal()
        {
            var weapons = _weaponPool.Pool.Where(x => x.template.Rarity == Core.Template.WeaponRarity.Normal).ToList();

            var weaponData = weapons[Random.Range(0, weapons.Count)];

            return weaponData;
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _pityData = GetComponent<IPityData>();
            _characterPool = Resources.Load<CharacterPool>("So/Pool/CharacterPool");
            _weaponPool = Resources.Load<WeaponPool>("So/Pool/WeaponPool");
            _itemCharacterFactory = Resources.Load<ItemCharacterFactory>("So/Factory/ItemCharacterFactory");
            _itemWeaponFactory = Resources.Load<ItemWeaponFactory>("So/Factory/ItemWeaponFactory");
            _pullHistory = GetComponent<IListContainer<string>>();
            _inventory = FindObjectsOfType<MonoBehaviour>().OfType<IInventory>().FirstOrDefault();
        }

        #endregion

        #region IPull

        [field: SerializeField]
        public Pulltype Pulltype { get; private set; } = default;

        [Button]
        public void DoPull(int amount)
        {
            var currentRarePity = _pityData.RarePity;
            var currentSuperRarePity = _pityData.SuperRarePity;

            var getWeapon = false;

            CharacterData characterData = default;
            WeaponData weaponData = default;

            for (int i = 0; i < amount; i++)
            {
                getWeapon = false;

                currentSuperRarePity--;
                currentRarePity--;

                if (currentSuperRarePity == _pityData.DefaultSuperRarePity / 2)
                {
                    var random = Random.Range(0, 2);
                    var get = random == 0;

                    if (get)
                    {
                        if (Pulltype == Pulltype.Character)
                        {
                            characterData = GetCharacterSuperRare();
                        }
                        else
                        {
                            weaponData = GetWeaponSuperRare();

                            getWeapon = true;
                        }

                        currentSuperRarePity = _pityData.DefaultSuperRarePity;
                    }
                }
                if (currentSuperRarePity <= 0)
                {
                    if (Pulltype == Pulltype.Character)
                    {
                        characterData = GetCharacterSuperRare();
                    }
                    else
                    {
                        weaponData = GetWeaponSuperRare();

                        getWeapon = true;
                    }

                    currentSuperRarePity = _pityData.DefaultSuperRarePity;
                }
                else if (currentRarePity <= 0)
                {
                    var random = Random.Range(0, 1f);

                    if (random >= .5f)
                    {
                        characterData = GetCharacterRare();
                    }
                    else
                    {
                        weaponData= GetWeaponRare();

                        getWeapon= true;
                    }

                    currentRarePity = _pityData.DefaultRarePity;
                }
                else
                {
                    // 5 star punya kemungkinan 0.6% untuk karakter
                    // 5 star punya kemungkinan 0.7% untuk weapon
                    // 4 star punya kemungkinan 5% untuk karakter
                    // 4 star punya kemungkinan 6% untuk weapon

                    var chance = Random.Range(0, 1f);

                    if (chance <= .006f && Pulltype == Pulltype.Character)
                    {
                        characterData = GetCharacterSuperRare();

                        currentSuperRarePity = _pityData.DefaultSuperRarePity;
                    }
                    else if (chance <= .007f && Pulltype == Pulltype.Weapon)
                    {
                        weaponData = GetWeaponSuperRare();

                        getWeapon = true;
                    }
                    else if (chance <= .05f)
                    {
                        characterData = GetCharacterRare();
                    }
                    else if (chance <= .06f)
                    {
                        weaponData = GetWeaponRare();

                        getWeapon = true;
                    }
                    else
                    {
                        weaponData = GetWeaponNormal();

                        getWeapon = true;
                    }
                }

                if (getWeapon)
                {
                    _pullHistory.Add(weaponData.id);

                    _inventory.AddItem(_itemWeaponFactory.Create(weaponData.id), 1);

                    // Debug.Log($"GetFreeItem Weapon {weaponData.name}, Rarity : {weaponData.template.Rarity}");
                }
                else
                {
                    _pullHistory.Add(characterData.id);

                    _inventory.AddItem(_itemCharacterFactory.Create(characterData.id), 1);

                    // Debug.Log($"GetFreeItem Character {characterData.name}, Rarity : {characterData.template.Rarity}");
                }
            }

            _pityData.SetRarePity(currentRarePity);
            _pityData.SetSuperRarePity(currentSuperRarePity);

            OnPullFinished?.Invoke(Pulltype, amount);
        }

        public Action<Pulltype, int> OnPullFinished { get; set; } = null;

        #endregion
    }
}