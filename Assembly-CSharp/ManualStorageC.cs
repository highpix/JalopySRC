using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Token: 0x020000CB RID: 203
public class ManualStorageC : MonoBehaviour
{
	// Token: 0x060007FA RID: 2042 RVA: 0x000A1AE0 File Offset: 0x0009FEE0
	private void Reset()
	{
		if (Application.isPlaying)
		{
			return;
		}
		ManualStorage component = base.GetComponent<ManualStorage>();
		this.storageText = component.storageText;
		this.bootInventory = component.bootInventory;
		this.roofInventory = component.roofInventory;
		this.weightText = component.weightText;
		this.totalWeightText = component.totalWeightText;
		this.inventoryCatalogue = new List<GameObject>(component.inventoryCatalogue);
		this.inventoryCatalogueStockCount = new List<int>(component.inventoryCatalogueStockCount);
		this.removeNumbers = new List<int>(component.removeNumbers);
		component.enabled = false;
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x000A1B78 File Offset: 0x0009FF78
	public void PageGo()
	{
		this.inventoryCatalogue.Clear();
		this.inventoryCatalogueStockCount.Clear();
		this.storageText.GetComponent<TextMeshPro>().text = string.Empty;
		this.weightText.GetComponent<TextMeshPro>().text = string.Empty;
		this.totalWeight = 0f;
		this.totalWeightText.GetComponent<TextMeshPro>().text = string.Empty;
		for (int i = 0; i < this.bootInventory.GetComponent<InventoryLogicC>().inventorySlots.Length; i++)
		{
			IEnumerator enumerator = this.bootInventory.GetComponent<InventoryLogicC>().inventorySlots[i].transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int j = 0; j < this.inventoryCatalogue.Count; j++)
						{
							if (transform.GetComponent<EngineComponentC>() && this.inventoryCatalogue[j].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[j].GetComponent<EngineComponentC>().componentHeader == transform.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index;
									(list = this.inventoryCatalogueStockCount)[index = j] = list[index] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[j].name == transform.name && !this.stockChecked)
							{
								List<int> list;
								int index2;
								(list = this.inventoryCatalogueStockCount)[index2 = j] = list[index2] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		for (int k = 0; k < this.bootInventory.GetComponent<InventoryLogicC>().slot3x2x1.Length; k++)
		{
			IEnumerator enumerator2 = this.bootInventory.GetComponent<InventoryLogicC>().slot3x2x1[k].transform.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj2 = enumerator2.Current;
					Transform transform2 = (Transform)obj2;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int l = 0; l < this.inventoryCatalogue.Count; l++)
						{
							if (transform2.GetComponent<EngineComponentC>() && this.inventoryCatalogue[l].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[l].GetComponent<EngineComponentC>().componentHeader == transform2.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index3;
									(list = this.inventoryCatalogueStockCount)[index3 = l] = list[index3] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[l].name == transform2.name && !this.stockChecked)
							{
								List<int> list;
								int index4;
								(list = this.inventoryCatalogueStockCount)[index4 = l] = list[index4] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform2.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform2.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		for (int m = 0; m < this.bootInventory.GetComponent<InventoryLogicC>().slot2x2x1.Length; m++)
		{
			IEnumerator enumerator3 = this.bootInventory.GetComponent<InventoryLogicC>().slot2x2x1[m].transform.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					object obj3 = enumerator3.Current;
					Transform transform3 = (Transform)obj3;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int n = 0; n < this.inventoryCatalogue.Count; n++)
						{
							if (transform3.GetComponent<EngineComponentC>() && this.inventoryCatalogue[n].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[n].GetComponent<EngineComponentC>().componentHeader == transform3.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index5;
									(list = this.inventoryCatalogueStockCount)[index5 = n] = list[index5] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[n].name == transform3.name && !this.stockChecked)
							{
								List<int> list;
								int index6;
								(list = this.inventoryCatalogueStockCount)[index6 = n] = list[index6] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform3.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform3.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator3 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
		}
		for (int num = 0; num < this.bootInventory.GetComponent<InventoryLogicC>().slot2x1x2.Length; num++)
		{
			IEnumerator enumerator4 = this.bootInventory.GetComponent<InventoryLogicC>().slot2x1x2[num].transform.GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object obj4 = enumerator4.Current;
					Transform transform4 = (Transform)obj4;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int num2 = 0; num2 < this.inventoryCatalogue.Count; num2++)
						{
							if (transform4.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num2].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[num2].GetComponent<EngineComponentC>().componentHeader == transform4.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index7;
									(list = this.inventoryCatalogueStockCount)[index7 = num2] = list[index7] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[num2].name == transform4.name && !this.stockChecked)
							{
								List<int> list;
								int index8;
								(list = this.inventoryCatalogueStockCount)[index8 = num2] = list[index8] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform4.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform4.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator4 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
		}
		for (int num3 = 0; num3 < this.bootInventory.GetComponent<InventoryLogicC>().slot2x2x2.Length; num3++)
		{
			IEnumerator enumerator5 = this.bootInventory.GetComponent<InventoryLogicC>().slot2x2x2[num3].transform.GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					object obj5 = enumerator5.Current;
					Transform transform5 = (Transform)obj5;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int num4 = 0; num4 < this.inventoryCatalogue.Count; num4++)
						{
							if (transform5.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num4].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[num4].GetComponent<EngineComponentC>().componentHeader == transform5.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index9;
									(list = this.inventoryCatalogueStockCount)[index9 = num4] = list[index9] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[num4].name == transform5.name && !this.stockChecked)
							{
								List<int> list;
								int index10;
								(list = this.inventoryCatalogueStockCount)[index10 = num4] = list[index10] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform5.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform5.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable5;
				if ((disposable5 = (enumerator5 as IDisposable)) != null)
				{
					disposable5.Dispose();
				}
			}
		}
		for (int num5 = 0; num5 < this.bootInventory.GetComponent<InventoryLogicC>().slot2x2x3.Length; num5++)
		{
			IEnumerator enumerator6 = this.bootInventory.GetComponent<InventoryLogicC>().slot2x2x3[num5].transform.GetEnumerator();
			try
			{
				while (enumerator6.MoveNext())
				{
					object obj6 = enumerator6.Current;
					Transform transform6 = (Transform)obj6;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int num6 = 0; num6 < this.inventoryCatalogue.Count; num6++)
						{
							if (transform6.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num6].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[num6].GetComponent<EngineComponentC>().componentHeader == transform6.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index11;
									(list = this.inventoryCatalogueStockCount)[index11 = num6] = list[index11] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[num6].name == transform6.name && !this.stockChecked)
							{
								List<int> list;
								int index12;
								(list = this.inventoryCatalogueStockCount)[index12 = num6] = list[index12] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform6.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform6.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable6;
				if ((disposable6 = (enumerator6 as IDisposable)) != null)
				{
					disposable6.Dispose();
				}
			}
		}
		for (int num7 = 0; num7 < this.bootInventory.GetComponent<InventoryLogicC>().slot3x2x3.Length; num7++)
		{
			IEnumerator enumerator7 = this.bootInventory.GetComponent<InventoryLogicC>().slot3x2x3[num7].transform.GetEnumerator();
			try
			{
				while (enumerator7.MoveNext())
				{
					object obj7 = enumerator7.Current;
					Transform transform7 = (Transform)obj7;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int num8 = 0; num8 < this.inventoryCatalogue.Count; num8++)
						{
							if (transform7.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num8].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[num8].GetComponent<EngineComponentC>().componentHeader == transform7.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index13;
									(list = this.inventoryCatalogueStockCount)[index13 = num8] = list[index13] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[num8].name == transform7.name && !this.stockChecked)
							{
								List<int> list;
								int index14;
								(list = this.inventoryCatalogueStockCount)[index14 = num8] = list[index14] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform7.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform7.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable7;
				if ((disposable7 = (enumerator7 as IDisposable)) != null)
				{
					disposable7.Dispose();
				}
			}
		}
		for (int num9 = 0; num9 < this.bootInventory.GetComponent<InventoryLogicC>().slot4x2x2.Length; num9++)
		{
			IEnumerator enumerator8 = this.bootInventory.GetComponent<InventoryLogicC>().slot4x2x2[num9].transform.GetEnumerator();
			try
			{
				while (enumerator8.MoveNext())
				{
					object obj8 = enumerator8.Current;
					Transform transform8 = (Transform)obj8;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int num10 = 0; num10 < this.inventoryCatalogue.Count; num10++)
						{
							if (transform8.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num10].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[num10].GetComponent<EngineComponentC>().componentHeader == transform8.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index15;
									(list = this.inventoryCatalogueStockCount)[index15 = num10] = list[index15] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[num10].name == transform8.name && !this.stockChecked)
							{
								List<int> list;
								int index16;
								(list = this.inventoryCatalogueStockCount)[index16 = num10] = list[index16] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform8.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform8.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable8;
				if ((disposable8 = (enumerator8 as IDisposable)) != null)
				{
					disposable8.Dispose();
				}
			}
		}
		for (int num11 = 0; num11 < this.bootInventory.GetComponent<InventoryLogicC>().slot4x2x3.Length; num11++)
		{
			IEnumerator enumerator9 = this.bootInventory.GetComponent<InventoryLogicC>().slot4x2x3[num11].transform.GetEnumerator();
			try
			{
				while (enumerator9.MoveNext())
				{
					object obj9 = enumerator9.Current;
					Transform transform9 = (Transform)obj9;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int num12 = 0; num12 < this.inventoryCatalogue.Count; num12++)
						{
							if (transform9.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num12].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[num12].GetComponent<EngineComponentC>().componentHeader == transform9.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index17;
									(list = this.inventoryCatalogueStockCount)[index17 = num12] = list[index17] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[num12].name == transform9.name && !this.stockChecked)
							{
								List<int> list;
								int index18;
								(list = this.inventoryCatalogueStockCount)[index18 = num12] = list[index18] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform9.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform9.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable9;
				if ((disposable9 = (enumerator9 as IDisposable)) != null)
				{
					disposable9.Dispose();
				}
			}
		}
		for (int num13 = 0; num13 < this.bootInventory.GetComponent<InventoryLogicC>().slot4x1x1.Length; num13++)
		{
			IEnumerator enumerator10 = this.bootInventory.GetComponent<InventoryLogicC>().slot4x1x1[num13].transform.GetEnumerator();
			try
			{
				while (enumerator10.MoveNext())
				{
					object obj10 = enumerator10.Current;
					Transform transform10 = (Transform)obj10;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int num14 = 0; num14 < this.inventoryCatalogue.Count; num14++)
						{
							if (transform10.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num14].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[num14].GetComponent<EngineComponentC>().componentHeader == transform10.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index19;
									(list = this.inventoryCatalogueStockCount)[index19 = num14] = list[index19] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[num14].name == transform10.name && !this.stockChecked)
							{
								List<int> list;
								int index20;
								(list = this.inventoryCatalogueStockCount)[index20 = num14] = list[index20] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform10.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform10.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable10;
				if ((disposable10 = (enumerator10 as IDisposable)) != null)
				{
					disposable10.Dispose();
				}
			}
		}
		for (int num15 = 0; num15 < this.bootInventory.GetComponent<InventoryLogicC>().slot4x2x1.Length; num15++)
		{
			IEnumerator enumerator11 = this.bootInventory.GetComponent<InventoryLogicC>().slot4x2x1[num15].transform.GetEnumerator();
			try
			{
				while (enumerator11.MoveNext())
				{
					object obj11 = enumerator11.Current;
					Transform transform11 = (Transform)obj11;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int num16 = 0; num16 < this.inventoryCatalogue.Count; num16++)
						{
							if (transform11.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num16].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[num16].GetComponent<EngineComponentC>().componentHeader == transform11.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index21;
									(list = this.inventoryCatalogueStockCount)[index21 = num16] = list[index21] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[num16].name == transform11.name && !this.stockChecked)
							{
								List<int> list;
								int index22;
								(list = this.inventoryCatalogueStockCount)[index22 = num16] = list[index22] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform11.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform11.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable11;
				if ((disposable11 = (enumerator11 as IDisposable)) != null)
				{
					disposable11.Dispose();
				}
			}
		}
		for (int num17 = 0; num17 < this.bootInventory.GetComponent<InventoryLogicC>().slot2x1x3.Length; num17++)
		{
			IEnumerator enumerator12 = this.bootInventory.GetComponent<InventoryLogicC>().slot2x1x3[num17].transform.GetEnumerator();
			try
			{
				while (enumerator12.MoveNext())
				{
					object obj12 = enumerator12.Current;
					Transform transform12 = (Transform)obj12;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int num18 = 0; num18 < this.inventoryCatalogue.Count; num18++)
						{
							if (transform12.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num18].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[num18].GetComponent<EngineComponentC>().componentHeader == transform12.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index23;
									(list = this.inventoryCatalogueStockCount)[index23 = num18] = list[index23] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[num18].name == transform12.name && !this.stockChecked)
							{
								List<int> list;
								int index24;
								(list = this.inventoryCatalogueStockCount)[index24 = num18] = list[index24] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform12.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform12.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable12;
				if ((disposable12 = (enumerator12 as IDisposable)) != null)
				{
					disposable12.Dispose();
				}
			}
		}
		if (this.roofInventory.transform.parent.gameObject.activeInHierarchy)
		{
			for (int num19 = 0; num19 < this.roofInventory.GetComponent<InventoryLogicC>().inventorySlots.Length; num19++)
			{
				IEnumerator enumerator13 = this.roofInventory.GetComponent<InventoryLogicC>().inventorySlots[num19].transform.GetEnumerator();
				try
				{
					while (enumerator13.MoveNext())
					{
						object obj13 = enumerator13.Current;
						Transform transform13 = (Transform)obj13;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num20 = 0; num20 < this.inventoryCatalogue.Count; num20++)
							{
								if (transform13.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num20].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num20].GetComponent<EngineComponentC>().componentHeader == transform13.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index25;
										(list = this.inventoryCatalogueStockCount)[index25 = num20] = list[index25] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num20].name == transform13.name && !this.stockChecked)
								{
									List<int> list;
									int index26;
									(list = this.inventoryCatalogueStockCount)[index26 = num20] = list[index26] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform13.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform13.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable13;
					if ((disposable13 = (enumerator13 as IDisposable)) != null)
					{
						disposable13.Dispose();
					}
				}
			}
			for (int num21 = 0; num21 < this.roofInventory.GetComponent<InventoryLogicC>().slot3x2x1.Length; num21++)
			{
				IEnumerator enumerator14 = this.roofInventory.GetComponent<InventoryLogicC>().slot3x2x1[num21].transform.GetEnumerator();
				try
				{
					while (enumerator14.MoveNext())
					{
						object obj14 = enumerator14.Current;
						Transform transform14 = (Transform)obj14;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num22 = 0; num22 < this.inventoryCatalogue.Count; num22++)
							{
								if (transform14.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num22].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num22].GetComponent<EngineComponentC>().componentHeader == transform14.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index27;
										(list = this.inventoryCatalogueStockCount)[index27 = num22] = list[index27] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num22].name == transform14.name && !this.stockChecked)
								{
									List<int> list;
									int index28;
									(list = this.inventoryCatalogueStockCount)[index28 = num22] = list[index28] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform14.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform14.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable14;
					if ((disposable14 = (enumerator14 as IDisposable)) != null)
					{
						disposable14.Dispose();
					}
				}
			}
			for (int num23 = 0; num23 < this.roofInventory.GetComponent<InventoryLogicC>().slot2x2x1.Length; num23++)
			{
				IEnumerator enumerator15 = this.roofInventory.GetComponent<InventoryLogicC>().slot2x2x1[num23].transform.GetEnumerator();
				try
				{
					while (enumerator15.MoveNext())
					{
						object obj15 = enumerator15.Current;
						Transform transform15 = (Transform)obj15;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num24 = 0; num24 < this.inventoryCatalogue.Count; num24++)
							{
								if (transform15.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num24].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num24].GetComponent<EngineComponentC>().componentHeader == transform15.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index29;
										(list = this.inventoryCatalogueStockCount)[index29 = num24] = list[index29] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num23].name == transform15.name && !this.stockChecked)
								{
									List<int> list;
									int index30;
									(list = this.inventoryCatalogueStockCount)[index30 = num24] = list[index30] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform15.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform15.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable15;
					if ((disposable15 = (enumerator15 as IDisposable)) != null)
					{
						disposable15.Dispose();
					}
				}
			}
			for (int num25 = 0; num25 < this.roofInventory.GetComponent<InventoryLogicC>().slot2x1x2.Length; num25++)
			{
				IEnumerator enumerator16 = this.roofInventory.GetComponent<InventoryLogicC>().slot2x1x2[num25].transform.GetEnumerator();
				try
				{
					while (enumerator16.MoveNext())
					{
						object obj16 = enumerator16.Current;
						Transform transform16 = (Transform)obj16;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num26 = 0; num26 < this.inventoryCatalogue.Count; num26++)
							{
								if (transform16.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num26].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num26].GetComponent<EngineComponentC>().componentHeader == transform16.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index31;
										(list = this.inventoryCatalogueStockCount)[index31 = num26] = list[index31] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num26].name == transform16.name && !this.stockChecked)
								{
									List<int> list;
									int index32;
									(list = this.inventoryCatalogueStockCount)[index32 = num26] = list[index32] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform16.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform16.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable16;
					if ((disposable16 = (enumerator16 as IDisposable)) != null)
					{
						disposable16.Dispose();
					}
				}
			}
			for (int num27 = 0; num27 < this.roofInventory.GetComponent<InventoryLogicC>().slot2x2x2.Length; num27++)
			{
				IEnumerator enumerator17 = this.roofInventory.GetComponent<InventoryLogicC>().slot2x2x2[num27].transform.GetEnumerator();
				try
				{
					while (enumerator17.MoveNext())
					{
						object obj17 = enumerator17.Current;
						Transform transform17 = (Transform)obj17;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num28 = 0; num28 < this.inventoryCatalogue.Count; num28++)
							{
								if (transform17.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num28].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num28].GetComponent<EngineComponentC>().componentHeader == transform17.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index33;
										(list = this.inventoryCatalogueStockCount)[index33 = num28] = list[index33] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num28].name == transform17.name && !this.stockChecked)
								{
									List<int> list;
									int index34;
									(list = this.inventoryCatalogueStockCount)[index34 = num28] = list[index34] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform17.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform17.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable17;
					if ((disposable17 = (enumerator17 as IDisposable)) != null)
					{
						disposable17.Dispose();
					}
				}
			}
			for (int num29 = 0; num29 < this.roofInventory.GetComponent<InventoryLogicC>().slot2x2x3.Length; num29++)
			{
				IEnumerator enumerator18 = this.roofInventory.GetComponent<InventoryLogicC>().slot2x2x3[num29].transform.GetEnumerator();
				try
				{
					while (enumerator18.MoveNext())
					{
						object obj18 = enumerator18.Current;
						Transform transform18 = (Transform)obj18;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num30 = 0; num30 < this.inventoryCatalogue.Count; num30++)
							{
								if (transform18.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num30].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num30].GetComponent<EngineComponentC>().componentHeader == transform18.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index35;
										(list = this.inventoryCatalogueStockCount)[index35 = num30] = list[index35] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num30].name == transform18.name && !this.stockChecked)
								{
									List<int> list;
									int index36;
									(list = this.inventoryCatalogueStockCount)[index36 = num30] = list[index36] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform18.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform18.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable18;
					if ((disposable18 = (enumerator18 as IDisposable)) != null)
					{
						disposable18.Dispose();
					}
				}
			}
			for (int num31 = 0; num31 < this.roofInventory.GetComponent<InventoryLogicC>().slot3x2x3.Length; num31++)
			{
				IEnumerator enumerator19 = this.roofInventory.GetComponent<InventoryLogicC>().slot3x2x3[num31].transform.GetEnumerator();
				try
				{
					while (enumerator19.MoveNext())
					{
						object obj19 = enumerator19.Current;
						Transform transform19 = (Transform)obj19;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num32 = 0; num32 < this.inventoryCatalogue.Count; num32++)
							{
								if (transform19.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num32].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num32].GetComponent<EngineComponentC>().componentHeader == transform19.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index37;
										(list = this.inventoryCatalogueStockCount)[index37 = num32] = list[index37] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num32].name == transform19.name && !this.stockChecked)
								{
									List<int> list;
									int index38;
									(list = this.inventoryCatalogueStockCount)[index38 = num32] = list[index38] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform19.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform19.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable19;
					if ((disposable19 = (enumerator19 as IDisposable)) != null)
					{
						disposable19.Dispose();
					}
				}
			}
			for (int num33 = 0; num33 < this.roofInventory.GetComponent<InventoryLogicC>().slot4x2x2.Length; num33++)
			{
				IEnumerator enumerator20 = this.roofInventory.GetComponent<InventoryLogicC>().slot4x2x2[num33].transform.GetEnumerator();
				try
				{
					while (enumerator20.MoveNext())
					{
						object obj20 = enumerator20.Current;
						Transform transform20 = (Transform)obj20;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num34 = 0; num34 < this.inventoryCatalogue.Count; num34++)
							{
								if (transform20.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num34].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num34].GetComponent<EngineComponentC>().componentHeader == transform20.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index39;
										(list = this.inventoryCatalogueStockCount)[index39 = num34] = list[index39] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num34].name == transform20.name && !this.stockChecked)
								{
									List<int> list;
									int index40;
									(list = this.inventoryCatalogueStockCount)[index40 = num34] = list[index40] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform20.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform20.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable20;
					if ((disposable20 = (enumerator20 as IDisposable)) != null)
					{
						disposable20.Dispose();
					}
				}
			}
			for (int num35 = 0; num35 < this.roofInventory.GetComponent<InventoryLogicC>().slot4x2x3.Length; num35++)
			{
				IEnumerator enumerator21 = this.roofInventory.GetComponent<InventoryLogicC>().slot4x2x3[num35].transform.GetEnumerator();
				try
				{
					while (enumerator21.MoveNext())
					{
						object obj21 = enumerator21.Current;
						Transform transform21 = (Transform)obj21;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num36 = 0; num36 < this.inventoryCatalogue.Count; num36++)
							{
								if (transform21.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num36].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num36].GetComponent<EngineComponentC>().componentHeader == transform21.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index41;
										(list = this.inventoryCatalogueStockCount)[index41 = num36] = list[index41] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num36].name == transform21.name && !this.stockChecked)
								{
									List<int> list;
									int index42;
									(list = this.inventoryCatalogueStockCount)[index42 = num36] = list[index42] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform21.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform21.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable21;
					if ((disposable21 = (enumerator21 as IDisposable)) != null)
					{
						disposable21.Dispose();
					}
				}
			}
			for (int num37 = 0; num37 < this.roofInventory.GetComponent<InventoryLogicC>().slot4x1x1.Length; num37++)
			{
				IEnumerator enumerator22 = this.roofInventory.GetComponent<InventoryLogicC>().slot4x1x1[num37].transform.GetEnumerator();
				try
				{
					while (enumerator22.MoveNext())
					{
						object obj22 = enumerator22.Current;
						Transform transform22 = (Transform)obj22;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num38 = 0; num38 < this.inventoryCatalogue.Count; num38++)
							{
								if (transform22.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num38].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num38].GetComponent<EngineComponentC>().componentHeader == transform22.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index43;
										(list = this.inventoryCatalogueStockCount)[index43 = num38] = list[index43] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num38].name == transform22.name && !this.stockChecked)
								{
									List<int> list;
									int index44;
									(list = this.inventoryCatalogueStockCount)[index44 = num38] = list[index44] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform22.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform22.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable22;
					if ((disposable22 = (enumerator22 as IDisposable)) != null)
					{
						disposable22.Dispose();
					}
				}
			}
			for (int num39 = 0; num39 < this.roofInventory.GetComponent<InventoryLogicC>().slot4x2x1.Length; num39++)
			{
				IEnumerator enumerator23 = this.roofInventory.GetComponent<InventoryLogicC>().slot4x2x1[num39].transform.GetEnumerator();
				try
				{
					while (enumerator23.MoveNext())
					{
						object obj23 = enumerator23.Current;
						Transform transform23 = (Transform)obj23;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num40 = 0; num40 < this.inventoryCatalogue.Count; num40++)
							{
								if (transform23.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num40].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num40].GetComponent<EngineComponentC>().componentHeader == transform23.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index45;
										(list = this.inventoryCatalogueStockCount)[index45 = num40] = list[index45] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num40].name == transform23.name && !this.stockChecked)
								{
									List<int> list;
									int index46;
									(list = this.inventoryCatalogueStockCount)[index46 = num40] = list[index46] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform23.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform23.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable23;
					if ((disposable23 = (enumerator23 as IDisposable)) != null)
					{
						disposable23.Dispose();
					}
				}
			}
			for (int num41 = 0; num41 < this.roofInventory.GetComponent<InventoryLogicC>().slot2x1x3.Length; num41++)
			{
				IEnumerator enumerator24 = this.roofInventory.GetComponent<InventoryLogicC>().slot2x1x3[num41].transform.GetEnumerator();
				try
				{
					while (enumerator24.MoveNext())
					{
						object obj24 = enumerator24.Current;
						Transform transform24 = (Transform)obj24;
						if (this.inventoryCatalogue.Count >= 1)
						{
							for (int num42 = 0; num42 < this.inventoryCatalogue.Count; num42++)
							{
								if (transform24.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num42].GetComponent<EngineComponentC>() && !this.stockChecked)
								{
									if (this.inventoryCatalogue[num42].GetComponent<EngineComponentC>().componentHeader == transform24.GetComponent<EngineComponentC>().componentHeader)
									{
										List<int> list;
										int index47;
										(list = this.inventoryCatalogueStockCount)[index47 = num42] = list[index47] + 1;
										this.stockChecked = true;
									}
								}
								else if (this.inventoryCatalogue[num42].name == transform24.name && !this.stockChecked)
								{
									List<int> list;
									int index48;
									(list = this.inventoryCatalogueStockCount)[index48 = num42] = list[index48] + 1;
									this.stockChecked = true;
								}
							}
							if (!this.stockChecked)
							{
								this.inventoryCatalogue.Add(transform24.gameObject);
								this.inventoryCatalogueStockCount.Add(1);
							}
						}
						else
						{
							this.inventoryCatalogue.Add(transform24.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
						this.stockChecked = false;
					}
				}
				finally
				{
					IDisposable disposable24;
					if ((disposable24 = (enumerator24 as IDisposable)) != null)
					{
						disposable24.Dispose();
					}
				}
			}
		}
		if (this.bootInventory.GetComponent<InventoryLogicC>().wheelHolder1 != null)
		{
			IEnumerator enumerator25 = this.bootInventory.GetComponent<InventoryLogicC>().wheelHolder1.transform.GetEnumerator();
			try
			{
				while (enumerator25.MoveNext())
				{
					object obj25 = enumerator25.Current;
					Transform transform25 = (Transform)obj25;
					if (this.inventoryCatalogue.Count >= 1)
					{
						for (int num43 = 0; num43 < this.inventoryCatalogue.Count; num43++)
						{
							if (transform25.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num43].GetComponent<EngineComponentC>() && !this.stockChecked)
							{
								if (this.inventoryCatalogue[num43].GetComponent<EngineComponentC>().componentHeader == transform25.GetComponent<EngineComponentC>().componentHeader)
								{
									List<int> list;
									int index49;
									(list = this.inventoryCatalogueStockCount)[index49 = num43] = list[index49] + 1;
									this.stockChecked = true;
								}
							}
							else if (this.inventoryCatalogue[num43].name == transform25.name && !this.stockChecked)
							{
								List<int> list;
								int index50;
								(list = this.inventoryCatalogueStockCount)[index50 = num43] = list[index50] + 1;
								this.stockChecked = true;
							}
						}
						if (!this.stockChecked)
						{
							this.inventoryCatalogue.Add(transform25.gameObject);
							this.inventoryCatalogueStockCount.Add(1);
						}
					}
					else
					{
						this.inventoryCatalogue.Add(transform25.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
					this.stockChecked = false;
				}
			}
			finally
			{
				IDisposable disposable25;
				if ((disposable25 = (enumerator25 as IDisposable)) != null)
				{
					disposable25.Dispose();
				}
			}
		}
		IEnumerator enumerator26 = this.bootInventory.GetComponent<InventoryLogicC>().wheelHolder2.transform.GetEnumerator();
		try
		{
			while (enumerator26.MoveNext())
			{
				object obj26 = enumerator26.Current;
				Transform transform26 = (Transform)obj26;
				if (this.inventoryCatalogue.Count >= 1)
				{
					for (int num44 = 0; num44 < this.inventoryCatalogue.Count; num44++)
					{
						if (transform26.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num44].GetComponent<EngineComponentC>() && !this.stockChecked)
						{
							if (this.inventoryCatalogue[num44].GetComponent<EngineComponentC>().componentHeader == transform26.GetComponent<EngineComponentC>().componentHeader)
							{
								List<int> list;
								int index51;
								(list = this.inventoryCatalogueStockCount)[index51 = num44] = list[index51] + 1;
								this.stockChecked = true;
							}
						}
						else if (this.inventoryCatalogue[num44].name == transform26.name && !this.stockChecked)
						{
							List<int> list;
							int index52;
							(list = this.inventoryCatalogueStockCount)[index52 = num44] = list[index52] + 1;
							this.stockChecked = true;
						}
					}
					if (!this.stockChecked)
					{
						this.inventoryCatalogue.Add(transform26.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
				}
				else
				{
					this.inventoryCatalogue.Add(transform26.gameObject);
					this.inventoryCatalogueStockCount.Add(1);
				}
				this.stockChecked = false;
			}
		}
		finally
		{
			IDisposable disposable26;
			if ((disposable26 = (enumerator26 as IDisposable)) != null)
			{
				disposable26.Dispose();
			}
		}
		IEnumerator enumerator27 = this.roofInventory.GetComponent<InventoryLogicC>().wheelHolder1.transform.GetEnumerator();
		try
		{
			while (enumerator27.MoveNext())
			{
				object obj27 = enumerator27.Current;
				Transform transform27 = (Transform)obj27;
				if (this.inventoryCatalogue.Count >= 1)
				{
					for (int num45 = 0; num45 < this.inventoryCatalogue.Count; num45++)
					{
						if (transform27.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num45].GetComponent<EngineComponentC>() && !this.stockChecked)
						{
							if (this.inventoryCatalogue[num45].GetComponent<EngineComponentC>().componentHeader == transform27.GetComponent<EngineComponentC>().componentHeader)
							{
								List<int> list;
								int index53;
								(list = this.inventoryCatalogueStockCount)[index53 = num45] = list[index53] + 1;
								this.stockChecked = true;
							}
						}
						else if (this.inventoryCatalogue[num45].name == transform27.name && !this.stockChecked)
						{
							List<int> list;
							int index54;
							(list = this.inventoryCatalogueStockCount)[index54 = num45] = list[index54] + 1;
							this.stockChecked = true;
						}
					}
					if (!this.stockChecked)
					{
						this.inventoryCatalogue.Add(transform27.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
				}
				else
				{
					this.inventoryCatalogue.Add(transform27.gameObject);
					this.inventoryCatalogueStockCount.Add(1);
				}
				this.stockChecked = false;
			}
		}
		finally
		{
			IDisposable disposable27;
			if ((disposable27 = (enumerator27 as IDisposable)) != null)
			{
				disposable27.Dispose();
			}
		}
		IEnumerator enumerator28 = this.roofInventory.GetComponent<InventoryLogicC>().wheelHolder2.transform.GetEnumerator();
		try
		{
			while (enumerator28.MoveNext())
			{
				object obj28 = enumerator28.Current;
				Transform transform28 = (Transform)obj28;
				if (this.inventoryCatalogue.Count >= 1)
				{
					for (int num46 = 0; num46 < this.inventoryCatalogue.Count; num46++)
					{
						if (transform28.GetComponent<EngineComponentC>() && this.inventoryCatalogue[num46].GetComponent<EngineComponentC>() && !this.stockChecked)
						{
							if (this.inventoryCatalogue[num46].GetComponent<EngineComponentC>().componentHeader == transform28.GetComponent<EngineComponentC>().componentHeader)
							{
								List<int> list;
								int index55;
								(list = this.inventoryCatalogueStockCount)[index55 = num46] = list[index55] + 1;
								this.stockChecked = true;
							}
						}
						else if (this.inventoryCatalogue[num46].name == transform28.name && !this.stockChecked)
						{
							List<int> list;
							int index56;
							(list = this.inventoryCatalogueStockCount)[index56 = num46] = list[index56] + 1;
							this.stockChecked = true;
						}
					}
					if (!this.stockChecked)
					{
						this.inventoryCatalogue.Add(transform28.gameObject);
						this.inventoryCatalogueStockCount.Add(1);
					}
				}
				else
				{
					this.inventoryCatalogue.Add(transform28.gameObject);
					this.inventoryCatalogueStockCount.Add(1);
				}
				this.stockChecked = false;
			}
		}
		finally
		{
			IDisposable disposable28;
			if ((disposable28 = (enumerator28 as IDisposable)) != null)
			{
				disposable28.Dispose();
			}
		}
		for (int num47 = 0; num47 < this.inventoryCatalogue.Count; num47++)
		{
			if (this.inventoryCatalogue[num47] != null)
			{
				if (this.inventoryCatalogue[num47].GetComponent<EngineComponentC>())
				{
					TextMeshPro component = this.storageText.GetComponent<TextMeshPro>();
					component.text += Language.Get(this.inventoryCatalogue[num47].GetComponent<EngineComponentC>().componentHeader, "Inspector_UI");
				}
				else
				{
					this.inventoryCatalogue[num47].name = this.inventoryCatalogue[num47].name.Replace("(Clone)", string.Empty).Trim();
					TextMeshPro component2 = this.storageText.GetComponent<TextMeshPro>();
					component2.text += this.inventoryCatalogue[num47].name;
				}
				if (this.inventoryCatalogueStockCount[num47] > 1)
				{
					TextMeshPro component3 = this.storageText.GetComponent<TextMeshPro>();
					component3.text += " x";
					TextMeshPro component4 = this.storageText.GetComponent<TextMeshPro>();
					component4.text += this.inventoryCatalogueStockCount[num47].ToString();
				}
				TextMeshPro component5 = this.storageText.GetComponent<TextMeshPro>();
				component5.text += "\\n";
				this.storageText.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
				if (this.inventoryCatalogueStockCount[num47] > 1)
				{
					float num48 = this.inventoryCatalogue[num47].GetComponent<ObjectPickupC>().rigidMass * (float)this.inventoryCatalogueStockCount[num47];
					TextMeshPro component6 = this.weightText.GetComponent<TextMeshPro>();
					component6.text = component6.text + "- " + num48.ToString() + " kg";
					this.totalWeight += num48;
				}
				else
				{
					TextMeshPro component7 = this.weightText.GetComponent<TextMeshPro>();
					component7.text = component7.text + "- " + this.inventoryCatalogue[num47].GetComponent<ObjectPickupC>().rigidMass.ToString() + " kg";
					this.totalWeight += this.inventoryCatalogue[num47].GetComponent<ObjectPickupC>().rigidMass;
				}
				TextMeshPro component8 = this.weightText.GetComponent<TextMeshPro>();
				component8.text += "\\n";
				this.weightText.GetComponent<TextMeshPro>().text.Replace("\\n", "\n");
			}
		}
		TextMeshPro component9 = this.totalWeightText.GetComponent<TextMeshPro>();
		component9.text = component9.text + this.totalWeight.ToString() + " kg";
	}

	// Token: 0x04000A50 RID: 2640
	public GameObject storageText;

	// Token: 0x04000A51 RID: 2641
	public GameObject bootInventory;

	// Token: 0x04000A52 RID: 2642
	public GameObject roofInventory;

	// Token: 0x04000A53 RID: 2643
	public GameObject weightText;

	// Token: 0x04000A54 RID: 2644
	public GameObject totalWeightText;

	// Token: 0x04000A55 RID: 2645
	public List<GameObject> inventoryCatalogue = new List<GameObject>();

	// Token: 0x04000A56 RID: 2646
	public List<int> inventoryCatalogueStockCount = new List<int>();

	// Token: 0x04000A57 RID: 2647
	public List<int> removeNumbers = new List<int>();

	// Token: 0x04000A58 RID: 2648
	private bool stockChecked;

	// Token: 0x04000A59 RID: 2649
	private float totalWeight;
}
