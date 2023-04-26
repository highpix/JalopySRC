using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200002C RID: 44
[Serializable]
public class SaveFile
{
	// Token: 0x040000A6 RID: 166
	public int plateStringIDDate;

	// Token: 0x040000A7 RID: 167
	public bool carDoorRepaired;

	// Token: 0x040000A8 RID: 168
	public int newMonitorIndex;

	// Token: 0x040000A9 RID: 169
	public bool fullScreenState;

	// Token: 0x040000AA RID: 170
	public bool reticule;

	// Token: 0x040000AB RID: 171
	public int mirrorState;

	// Token: 0x040000AC RID: 172
	public List<int> home1inventorySaveList = new List<int>();

	// Token: 0x040000AD RID: 173
	public List<int> home2inventorySaveList = new List<int>();

	// Token: 0x040000AE RID: 174
	public List<int> home3inventorySaveList = new List<int>();

	// Token: 0x040000AF RID: 175
	public List<int> home4inventorySaveList = new List<int>();

	// Token: 0x040000B0 RID: 176
	public List<int> home5inventorySaveList = new List<int>();

	// Token: 0x040000B1 RID: 177
	public List<int> bootInventorySaveListsTyres = new List<int>();

	// Token: 0x040000B2 RID: 178
	public List<int> bootInventorySaveLists3x2x1 = new List<int>();

	// Token: 0x040000B3 RID: 179
	public List<int> bootInventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x040000B4 RID: 180
	public List<int> bootInventorySaveLists2x2x1 = new List<int>();

	// Token: 0x040000B5 RID: 181
	public List<int> bootInventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x040000B6 RID: 182
	public List<int> bootInventorySaveLists3x2x3 = new List<int>();

	// Token: 0x040000B7 RID: 183
	public List<int> bootInventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x040000B8 RID: 184
	public List<int> bootInventorySaveLists4x2x2 = new List<int>();

	// Token: 0x040000B9 RID: 185
	public List<int> bootInventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x040000BA RID: 186
	public List<int> bootInventorySaveLists4x2x1 = new List<int>();

	// Token: 0x040000BB RID: 187
	public List<int> bootInventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x040000BC RID: 188
	public List<int> roofInventorySaveList = new List<int>();

	// Token: 0x040000BD RID: 189
	public List<int> roofInventorySaveLocsSingle = new List<int>();

	// Token: 0x040000BE RID: 190
	public List<int> roofInventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x040000BF RID: 191
	public List<int> roofInventorySaveLists3x2x1 = new List<int>();

	// Token: 0x040000C0 RID: 192
	public List<int> roofInventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x040000C1 RID: 193
	public List<int> roofInventorySaveLists2x2x1 = new List<int>();

	// Token: 0x040000C2 RID: 194
	public List<int> roofInventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x040000C3 RID: 195
	public List<int> roofInventorySaveLists2x2x3 = new List<int>();

	// Token: 0x040000C4 RID: 196
	public List<int> roofInventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x040000C5 RID: 197
	public List<int> roofInventorySaveLists2x2x2 = new List<int>();

	// Token: 0x040000C6 RID: 198
	public List<int> roofInventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x040000C7 RID: 199
	public List<int> roofInventorySaveLists3x2x3 = new List<int>();

	// Token: 0x040000C8 RID: 200
	public List<int> roofInventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x040000C9 RID: 201
	public List<int> roofInventorySaveLists4x2x2 = new List<int>();

	// Token: 0x040000CA RID: 202
	public List<int> roofInventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x040000CB RID: 203
	public List<int> roofInventorySaveLists4x2x3 = new List<int>();

	// Token: 0x040000CC RID: 204
	public List<int> roofInventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x040000CD RID: 205
	public List<int> roofInventorySaveLists4x1x1 = new List<int>();

	// Token: 0x040000CE RID: 206
	public List<int> roofInventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x040000CF RID: 207
	public List<int> roofInventorySaveLists4x2x1 = new List<int>();

	// Token: 0x040000D0 RID: 208
	public List<int> roofInventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x040000D1 RID: 209
	public List<int> roofInventorySaveLists2x1x3 = new List<int>();

	// Token: 0x040000D2 RID: 210
	public List<int> roofInventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x040000D3 RID: 211
	public List<int> roofInventorySaveListsTyres = new List<int>();

	// Token: 0x040000D4 RID: 212
	public List<int> basketInventorySaveList = new List<int>();

	// Token: 0x040000D5 RID: 213
	public List<int> currentBasketsInInventory = new List<int>();

	// Token: 0x040000D6 RID: 214
	public List<int> bootInventorySaveLists2x2x2 = new List<int>();

	// Token: 0x040000D7 RID: 215
	public List<int> bootInventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x040000D8 RID: 216
	public List<int> waterBottleLevels = new List<int>();

	// Token: 0x040000D9 RID: 217
	public List<int> bootInventorySaveLists2x1x3 = new List<int>();

	// Token: 0x040000DA RID: 218
	public List<int> bootInventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x040000DB RID: 219
	public List<int> bootInventorySaveLists2x2x3 = new List<int>();

	// Token: 0x040000DC RID: 220
	public List<int> bootInventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x040000DD RID: 221
	public List<int> bootInventorySaveLists4x2x3 = new List<int>();

	// Token: 0x040000DE RID: 222
	public List<int> bootInventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x040000DF RID: 223
	public List<int> bootInventorySaveLists4x1x1 = new List<int>();

	// Token: 0x040000E0 RID: 224
	public List<int> bootInventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x040000E1 RID: 225
	public List<int> bootInventorySaveList = new List<int>();

	// Token: 0x040000E2 RID: 226
	public List<int> bootInventorySaveLocsSingle = new List<int>();

	// Token: 0x040000E3 RID: 227
	public List<int> bootInventoryTradegoodsSmallIDSaveList = new List<int>();

	// Token: 0x040000E4 RID: 228
	public List<int> home1InventorySaveListsTyres = new List<int>();

	// Token: 0x040000E5 RID: 229
	public List<int> home2InventorySaveListsTyres = new List<int>();

	// Token: 0x040000E6 RID: 230
	public List<int> home3InventorySaveListsTyres = new List<int>();

	// Token: 0x040000E7 RID: 231
	public List<int> home4InventorySaveListsTyres = new List<int>();

	// Token: 0x040000E8 RID: 232
	public List<int> home5InventorySaveListsTyres = new List<int>();

	// Token: 0x040000E9 RID: 233
	public bool home1inventoryInstalled;

	// Token: 0x040000EA RID: 234
	public List<int> home1InventorySaveLists4x1x1 = new List<int>();

	// Token: 0x040000EB RID: 235
	public List<int> home1InventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x040000EC RID: 236
	public List<int> home1InventorySaveLists3x2x1 = new List<int>();

	// Token: 0x040000ED RID: 237
	public List<int> home1InventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x040000EE RID: 238
	public List<int> home1InventorySaveLists2x2x1 = new List<int>();

	// Token: 0x040000EF RID: 239
	public List<int> home1InventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x040000F0 RID: 240
	public List<int> home1InventorySaveLists3x2x3 = new List<int>();

	// Token: 0x040000F1 RID: 241
	public List<int> home1InventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x040000F2 RID: 242
	public List<int> home1InventorySaveLists4x2x2 = new List<int>();

	// Token: 0x040000F3 RID: 243
	public List<int> home1InventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x040000F4 RID: 244
	public List<int> home1InventorySaveLists4x2x1 = new List<int>();

	// Token: 0x040000F5 RID: 245
	public List<int> home1InventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x040000F6 RID: 246
	public List<int> home1InventorySaveLists2x1x3 = new List<int>();

	// Token: 0x040000F7 RID: 247
	public List<int> home1InventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x040000F8 RID: 248
	public List<int> home1InventorySaveLists2x1x2 = new List<int>();

	// Token: 0x040000F9 RID: 249
	public List<int> home1InventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x040000FA RID: 250
	public List<int> home1InventorySaveLists2x2x2 = new List<int>();

	// Token: 0x040000FB RID: 251
	public List<int> home1InventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x040000FC RID: 252
	public List<int> home1InventorySaveLists2x2x3 = new List<int>();

	// Token: 0x040000FD RID: 253
	public List<int> home1InventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x040000FE RID: 254
	public List<int> home1InventorySaveLists4x2x3 = new List<int>();

	// Token: 0x040000FF RID: 255
	public List<int> home1InventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x04000100 RID: 256
	public List<int> home1InventorySaveLists4x2x4 = new List<int>();

	// Token: 0x04000101 RID: 257
	public List<int> home1InventorySaveLocs4x2x4 = new List<int>();

	// Token: 0x04000102 RID: 258
	public List<int> home1InventorySaveLocsSingle = new List<int>();

	// Token: 0x04000103 RID: 259
	public List<int> home1InventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x04000104 RID: 260
	public bool home2inventoryInstalled;

	// Token: 0x04000105 RID: 261
	public List<int> home2InventorySaveLists4x1x1 = new List<int>();

	// Token: 0x04000106 RID: 262
	public List<int> home2InventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x04000107 RID: 263
	public List<int> home2InventorySaveLists3x2x1 = new List<int>();

	// Token: 0x04000108 RID: 264
	public List<int> home2InventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x04000109 RID: 265
	public List<int> home2InventorySaveLists2x2x1 = new List<int>();

	// Token: 0x0400010A RID: 266
	public List<int> home2InventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x0400010B RID: 267
	public List<int> home2InventorySaveLists3x2x3 = new List<int>();

	// Token: 0x0400010C RID: 268
	public List<int> home2InventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x0400010D RID: 269
	public List<int> home2InventorySaveLists4x2x2 = new List<int>();

	// Token: 0x0400010E RID: 270
	public List<int> home2InventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x0400010F RID: 271
	public List<int> home2InventorySaveLists4x2x1 = new List<int>();

	// Token: 0x04000110 RID: 272
	public List<int> home2InventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x04000111 RID: 273
	public List<int> home2InventorySaveLists2x1x3 = new List<int>();

	// Token: 0x04000112 RID: 274
	public List<int> home2InventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x04000113 RID: 275
	public List<int> home2InventorySaveLists2x1x2 = new List<int>();

	// Token: 0x04000114 RID: 276
	public List<int> home2InventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x04000115 RID: 277
	public List<int> home2InventorySaveLists2x2x2 = new List<int>();

	// Token: 0x04000116 RID: 278
	public List<int> home2InventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x04000117 RID: 279
	public List<int> home2InventorySaveLists2x2x3 = new List<int>();

	// Token: 0x04000118 RID: 280
	public List<int> home2InventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x04000119 RID: 281
	public List<int> home2InventorySaveLists4x2x3 = new List<int>();

	// Token: 0x0400011A RID: 282
	public List<int> home2InventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x0400011B RID: 283
	public List<int> home2InventorySaveLists4x2x4 = new List<int>();

	// Token: 0x0400011C RID: 284
	public List<int> home2InventorySaveLocs4x2x4 = new List<int>();

	// Token: 0x0400011D RID: 285
	public List<int> home2InventorySaveLocsSingle = new List<int>();

	// Token: 0x0400011E RID: 286
	public List<int> home2InventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x0400011F RID: 287
	public bool home3inventoryInstalled;

	// Token: 0x04000120 RID: 288
	public List<int> home3InventorySaveLists4x1x1 = new List<int>();

	// Token: 0x04000121 RID: 289
	public List<int> home3InventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x04000122 RID: 290
	public List<int> home3InventorySaveLists3x2x1 = new List<int>();

	// Token: 0x04000123 RID: 291
	public List<int> home3InventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x04000124 RID: 292
	public List<int> home3InventorySaveLists2x2x1 = new List<int>();

	// Token: 0x04000125 RID: 293
	public List<int> home3InventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x04000126 RID: 294
	public List<int> home3InventorySaveLists3x2x3 = new List<int>();

	// Token: 0x04000127 RID: 295
	public List<int> home3InventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x04000128 RID: 296
	public List<int> home3InventorySaveLists4x2x2 = new List<int>();

	// Token: 0x04000129 RID: 297
	public List<int> home3InventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x0400012A RID: 298
	public List<int> home3InventorySaveLists4x2x1 = new List<int>();

	// Token: 0x0400012B RID: 299
	public List<int> home3InventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x0400012C RID: 300
	public List<int> home3InventorySaveLists2x1x3 = new List<int>();

	// Token: 0x0400012D RID: 301
	public List<int> home3InventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x0400012E RID: 302
	public List<int> home3InventorySaveLists2x1x2 = new List<int>();

	// Token: 0x0400012F RID: 303
	public List<int> home3InventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x04000130 RID: 304
	public List<int> home3InventorySaveLists2x2x2 = new List<int>();

	// Token: 0x04000131 RID: 305
	public List<int> home3InventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x04000132 RID: 306
	public List<int> home3InventorySaveLists2x2x3 = new List<int>();

	// Token: 0x04000133 RID: 307
	public List<int> home3InventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x04000134 RID: 308
	public List<int> home3InventorySaveLists4x2x3 = new List<int>();

	// Token: 0x04000135 RID: 309
	public List<int> home3InventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x04000136 RID: 310
	public List<int> home3InventorySaveLists4x2x4 = new List<int>();

	// Token: 0x04000137 RID: 311
	public List<int> home3InventorySaveLocs4x2x4 = new List<int>();

	// Token: 0x04000138 RID: 312
	public List<int> home3InventorySaveLocsSingle = new List<int>();

	// Token: 0x04000139 RID: 313
	public List<int> home3InventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x0400013A RID: 314
	public bool home4inventoryInstalled;

	// Token: 0x0400013B RID: 315
	public List<int> home4InventorySaveLists4x1x1 = new List<int>();

	// Token: 0x0400013C RID: 316
	public List<int> home4InventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x0400013D RID: 317
	public List<int> home4InventorySaveLists3x2x1 = new List<int>();

	// Token: 0x0400013E RID: 318
	public List<int> home4InventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x0400013F RID: 319
	public List<int> home4InventorySaveLists2x2x1 = new List<int>();

	// Token: 0x04000140 RID: 320
	public List<int> home4InventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x04000141 RID: 321
	public List<int> home4InventorySaveLists3x2x3 = new List<int>();

	// Token: 0x04000142 RID: 322
	public List<int> home4InventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x04000143 RID: 323
	public List<int> home4InventorySaveLists4x2x2 = new List<int>();

	// Token: 0x04000144 RID: 324
	public List<int> home4InventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x04000145 RID: 325
	public List<int> home4InventorySaveLists4x2x1 = new List<int>();

	// Token: 0x04000146 RID: 326
	public List<int> home4InventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x04000147 RID: 327
	public List<int> home4InventorySaveLists2x1x3 = new List<int>();

	// Token: 0x04000148 RID: 328
	public List<int> home4InventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x04000149 RID: 329
	public List<int> home4InventorySaveLists2x1x2 = new List<int>();

	// Token: 0x0400014A RID: 330
	public List<int> home4InventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x0400014B RID: 331
	public List<int> home4InventorySaveLists2x2x2 = new List<int>();

	// Token: 0x0400014C RID: 332
	public List<int> home4InventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x0400014D RID: 333
	public List<int> home4InventorySaveLists2x2x3 = new List<int>();

	// Token: 0x0400014E RID: 334
	public List<int> home4InventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x0400014F RID: 335
	public List<int> home4InventorySaveLists4x2x3 = new List<int>();

	// Token: 0x04000150 RID: 336
	public List<int> home4InventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x04000151 RID: 337
	public List<int> home4InventorySaveLists4x2x4 = new List<int>();

	// Token: 0x04000152 RID: 338
	public List<int> home4InventorySaveLocs4x2x4 = new List<int>();

	// Token: 0x04000153 RID: 339
	public List<int> home4InventorySaveLocsSingle = new List<int>();

	// Token: 0x04000154 RID: 340
	public List<int> home4InventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x04000155 RID: 341
	public bool home5inventoryInstalled;

	// Token: 0x04000156 RID: 342
	public List<int> home5InventorySaveLists4x1x1 = new List<int>();

	// Token: 0x04000157 RID: 343
	public List<int> home5InventorySaveLocs4x1x1 = new List<int>();

	// Token: 0x04000158 RID: 344
	public List<int> home5InventorySaveLists3x2x1 = new List<int>();

	// Token: 0x04000159 RID: 345
	public List<int> home5InventorySaveLocs3x2x1 = new List<int>();

	// Token: 0x0400015A RID: 346
	public List<int> home5InventorySaveLists2x2x1 = new List<int>();

	// Token: 0x0400015B RID: 347
	public List<int> home5InventorySaveLocs2x2x1 = new List<int>();

	// Token: 0x0400015C RID: 348
	public List<int> home5InventorySaveLists3x2x3 = new List<int>();

	// Token: 0x0400015D RID: 349
	public List<int> home5InventorySaveLocs3x2x3 = new List<int>();

	// Token: 0x0400015E RID: 350
	public List<int> home5InventorySaveLists4x2x2 = new List<int>();

	// Token: 0x0400015F RID: 351
	public List<int> home5InventorySaveLocs4x2x2 = new List<int>();

	// Token: 0x04000160 RID: 352
	public List<int> home5InventorySaveLists4x2x1 = new List<int>();

	// Token: 0x04000161 RID: 353
	public List<int> home5InventorySaveLocs4x2x1 = new List<int>();

	// Token: 0x04000162 RID: 354
	public List<int> home5InventorySaveLists2x1x3 = new List<int>();

	// Token: 0x04000163 RID: 355
	public List<int> home5InventorySaveLocs2x1x3 = new List<int>();

	// Token: 0x04000164 RID: 356
	public List<int> home5InventorySaveLists2x1x2 = new List<int>();

	// Token: 0x04000165 RID: 357
	public List<int> home5InventorySaveLocs2x1x2 = new List<int>();

	// Token: 0x04000166 RID: 358
	public List<int> home5InventorySaveLists2x2x2 = new List<int>();

	// Token: 0x04000167 RID: 359
	public List<int> home5InventorySaveLocs2x2x2 = new List<int>();

	// Token: 0x04000168 RID: 360
	public List<int> home5InventorySaveLists2x2x3 = new List<int>();

	// Token: 0x04000169 RID: 361
	public List<int> home5InventorySaveLocs2x2x3 = new List<int>();

	// Token: 0x0400016A RID: 362
	public List<int> home5InventorySaveLists4x2x3 = new List<int>();

	// Token: 0x0400016B RID: 363
	public List<int> home5InventorySaveLocs4x2x3 = new List<int>();

	// Token: 0x0400016C RID: 364
	public List<int> home5InventorySaveLists4x2x4 = new List<int>();

	// Token: 0x0400016D RID: 365
	public List<int> home5InventorySaveLocs4x2x4 = new List<int>();

	// Token: 0x0400016E RID: 366
	public List<int> home5InventorySaveLocsSingle = new List<int>();

	// Token: 0x0400016F RID: 367
	public List<int> home5InventoryTradeGoodsSmallIDSaveList = new List<int>();

	// Token: 0x04000170 RID: 368
	public List<int> fuelCanLevels = new List<int>();

	// Token: 0x04000171 RID: 369
	public List<int> fuelCanMixs = new List<int>();

	// Token: 0x04000172 RID: 370
	public List<float> componentFuels = new List<float>();

	// Token: 0x04000173 RID: 371
	public List<int> componentFuelMixs = new List<int>();

	// Token: 0x04000174 RID: 372
	public List<float> componentCharges = new List<float>();

	// Token: 0x04000175 RID: 373
	public List<int> componentWaters = new List<int>();

	// Token: 0x04000176 RID: 374
	public bool stampSave0;

	// Token: 0x04000177 RID: 375
	public bool stampSave1;

	// Token: 0x04000178 RID: 376
	public bool stampSave2;

	// Token: 0x04000179 RID: 377
	public bool stampSave3;

	// Token: 0x0400017A RID: 378
	public bool stampSave4;

	// Token: 0x0400017B RID: 379
	public bool stampSave5;

	// Token: 0x0400017C RID: 380
	public int motelRoomAssigned;

	// Token: 0x0400017D RID: 381
	public bool shopIsWelcomed;

	// Token: 0x0400017E RID: 382
	public bool preventFlickerLight;

	// Token: 0x0400017F RID: 383
	public bool savedStolenGoods;

	// Token: 0x04000180 RID: 384
	public bool alarmSilent;

	// Token: 0x04000181 RID: 385
	public float fov;

	// Token: 0x04000182 RID: 386
	public float masterVolume = 0.5f;

	// Token: 0x04000183 RID: 387
	public float effectsVolume = 0.5f;

	// Token: 0x04000184 RID: 388
	public float musicVolume = 0.5f;

	// Token: 0x04000185 RID: 389
	public int plateStringID;

	// Token: 0x04000186 RID: 390
	public bool preventFlickeringLights;

	// Token: 0x04000187 RID: 391
	public int resolutionX;

	// Token: 0x04000188 RID: 392
	public int resolutionY;

	// Token: 0x04000189 RID: 393
	public int vSyncState;

	// Token: 0x0400018A RID: 394
	public int aiCount = 3;

	// Token: 0x0400018B RID: 395
	public int qualityState;

	// Token: 0x0400018C RID: 396
	public bool mouseSmooth;

	// Token: 0x0400018D RID: 397
	public int padInput2;

	// Token: 0x0400018E RID: 398
	public float odometerTotalDistance;

	// Token: 0x0400018F RID: 399
	public bool aaSetting = true;

	// Token: 0x04000190 RID: 400
	public bool ssaoSetting = true;

	// Token: 0x04000191 RID: 401
	public bool mirrorEnabled;

	// Token: 0x04000192 RID: 402
	public float mouseSensitivity = 0.5f;

	// Token: 0x04000193 RID: 403
	public bool lookInvert;

	// Token: 0x04000194 RID: 404
	public float moneyAmount = 100f;

	// Token: 0x04000195 RID: 405
	public bool uncleStoryCompleted;

	// Token: 0x04000196 RID: 406
	public float airFilterCondition;

	// Token: 0x04000197 RID: 407
	public float carEngineCondition;

	// Token: 0x04000198 RID: 408
	public float ignitionCoilCondition;

	// Token: 0x04000199 RID: 409
	public float fuelTankCondition;

	// Token: 0x0400019A RID: 410
	public float fuelTankFuelAmount;

	// Token: 0x0400019B RID: 411
	public float carburettorCondition;

	// Token: 0x0400019C RID: 412
	public float waterTankCondition;

	// Token: 0x0400019D RID: 413
	public float batteryCondition;

	// Token: 0x0400019E RID: 414
	public float batteryCharges;

	// Token: 0x0400019F RID: 415
	public float flWheelCondition;

	// Token: 0x040001A0 RID: 416
	public float rlWheelCondition;

	// Token: 0x040001A1 RID: 417
	public float rrWheelCondition;

	// Token: 0x040001A2 RID: 418
	public float frWheelCondition;

	// Token: 0x040001A3 RID: 419
	public bool frTyrePurist;

	// Token: 0x040001A4 RID: 420
	public bool flTyrePurist;

	// Token: 0x040001A5 RID: 421
	public bool batteryPurist;

	// Token: 0x040001A6 RID: 422
	public bool waterTankPurist;

	// Token: 0x040001A7 RID: 423
	public bool carburettorPurist;

	// Token: 0x040001A8 RID: 424
	public bool airFilterPurist;

	// Token: 0x040001A9 RID: 425
	public bool fuelTankPurist;

	// Token: 0x040001AA RID: 426
	public bool ignitionCoilPurist;

	// Token: 0x040001AB RID: 427
	public bool carEnginePurist;

	// Token: 0x040001AC RID: 428
	public bool rlTyrePurist;

	// Token: 0x040001AD RID: 429
	public bool rrTyrePurist;

	// Token: 0x040001AE RID: 430
	public int fuelTankFuelMix;

	// Token: 0x040001AF RID: 431
	public int waterTankWaterCharges;

	// Token: 0x040001B0 RID: 432
	public float gerGoodTracker;

	// Token: 0x040001B1 RID: 433
	public float csfrGoodTracker;

	// Token: 0x040001B2 RID: 434
	public float hunGoodTracker;

	// Token: 0x040001B3 RID: 435
	public float yugoGoodTracker;

	// Token: 0x040001B4 RID: 436
	public float bulGoodTracker;

	// Token: 0x040001B5 RID: 437
	public float turkGoodTracker;

	// Token: 0x040001B6 RID: 438
	public int cleanedTimes;

	// Token: 0x040001B7 RID: 439
	public bool doorFitted;

	// Token: 0x040001B8 RID: 440
	public float frntDirt;

	// Token: 0x040001B9 RID: 441
	public float rearDirt;

	// Token: 0x040001BA RID: 442
	public float frntlsideDirt;

	// Token: 0x040001BB RID: 443
	public float doorlsideDirt;

	// Token: 0x040001BC RID: 444
	public float doorlsideDirt2;

	// Token: 0x040001BD RID: 445
	public float rearlsideDirt;

	// Token: 0x040001BE RID: 446
	public float frntrsideDirt;

	// Token: 0x040001BF RID: 447
	public float doorrsideDirt;

	// Token: 0x040001C0 RID: 448
	public float doorrsideDirt2;

	// Token: 0x040001C1 RID: 449
	public float rearrsideDirt;

	// Token: 0x040001C2 RID: 450
	public float flWheelDirt;

	// Token: 0x040001C3 RID: 451
	public float frWheelDirt;

	// Token: 0x040001C4 RID: 452
	public float rrWheelDirt;

	// Token: 0x040001C5 RID: 453
	public float rlWheelDirt;

	// Token: 0x040001C6 RID: 454
	public float frontWindowDirtRim;

	// Token: 0x040001C7 RID: 455
	public float frontWindowDirtWipers;

	// Token: 0x040001C8 RID: 456
	public float frontWindowDirtSmudge;

	// Token: 0x040001C9 RID: 457
	public float frontLeftWindowDirt;

	// Token: 0x040001CA RID: 458
	public float frontRightWindowDirt;

	// Token: 0x040001CB RID: 459
	public float rearLeftWindowDirt;

	// Token: 0x040001CC RID: 460
	public float rearRightWindowDirt;

	// Token: 0x040001CD RID: 461
	public float rearWindowDirt;

	// Token: 0x040001CE RID: 462
	public int carEngineID;

	// Token: 0x040001CF RID: 463
	public int ignitionCoilID;

	// Token: 0x040001D0 RID: 464
	public int fuelTankID;

	// Token: 0x040001D1 RID: 465
	public int carburettorID;

	// Token: 0x040001D2 RID: 466
	public int airFilterID;

	// Token: 0x040001D3 RID: 467
	public int waterTankID;

	// Token: 0x040001D4 RID: 468
	public int batteryID;

	// Token: 0x040001D5 RID: 469
	public int frWheelID;

	// Token: 0x040001D6 RID: 470
	public int flWheelID;

	// Token: 0x040001D7 RID: 471
	public int rrWheelID;

	// Token: 0x040001D8 RID: 472
	public int rlWheelID;

	// Token: 0x040001D9 RID: 473
	public float flCompoundID;

	// Token: 0x040001DA RID: 474
	public float frCompoundID;

	// Token: 0x040001DB RID: 475
	public float rlCompoundID;

	// Token: 0x040001DC RID: 476
	public float rrCompoundID;

	// Token: 0x040001DD RID: 477
	public bool roofRackInstalled;

	// Token: 0x040001DE RID: 478
	public bool bullBarInstalled;

	// Token: 0x040001DF RID: 479
	public bool mudGuardsInstalled;

	// Token: 0x040001E0 RID: 480
	public bool dashUIInstalled;

	// Token: 0x040001E1 RID: 481
	public bool lightRackInstalled;

	// Token: 0x040001E2 RID: 482
	public bool toolRackInstalled;

	// Token: 0x040001E3 RID: 483
	public int toolRackWeight;

	// Token: 0x040001E4 RID: 484
	public int toolRackLevel;

	// Token: 0x040001E5 RID: 485
	public int roofRackWeight;

	// Token: 0x040001E6 RID: 486
	public int lightRackWeight;

	// Token: 0x040001E7 RID: 487
	public int dashUIWeight;

	// Token: 0x040001E8 RID: 488
	public int mudGuardsWeight;

	// Token: 0x040001E9 RID: 489
	public int bullBarWeight;

	// Token: 0x040001EA RID: 490
	public bool uncleTutorialCompleted;

	// Token: 0x040001EB RID: 491
	public int daysPassed;

	// Token: 0x040001EC RID: 492
	public int footStepsCounter;

	// Token: 0x040001ED RID: 493
	public float fuelUsedStats;

	// Token: 0x040001EE RID: 494
	public int tyrePoppedStats;

	// Token: 0x040001EF RID: 495
	public float topSpeedStats;

	// Token: 0x040001F0 RID: 496
	public int repairKitsUsedStats;

	// Token: 0x040001F1 RID: 497
	[Header("Paint")]
	public ColorClass customPaintBonnet = new ColorClass();

	// Token: 0x040001F2 RID: 498
	public ColorClass customMetallicPaintBonnet = new ColorClass();

	// Token: 0x040001F3 RID: 499
	public ColorClass customPaintFrame = new ColorClass();

	// Token: 0x040001F4 RID: 500
	public ColorClass customMetallicPaintFrame = new ColorClass();

	// Token: 0x040001F5 RID: 501
	public ColorClass customPaintIntFloor = new ColorClass();

	// Token: 0x040001F6 RID: 502
	public ColorClass customMetallicPaintIntFloor = new ColorClass();

	// Token: 0x040001F7 RID: 503
	public ColorClass customPaintLDoor = new ColorClass();

	// Token: 0x040001F8 RID: 504
	public ColorClass customMetallicPaintLDoor = new ColorClass();

	// Token: 0x040001F9 RID: 505
	public ColorClass customPaintRDoor = new ColorClass();

	// Token: 0x040001FA RID: 506
	public ColorClass customMetallicPaintRDoor = new ColorClass();

	// Token: 0x040001FB RID: 507
	public ColorClass customPaintLHLight = new ColorClass();

	// Token: 0x040001FC RID: 508
	public ColorClass customMetallicPaintLHLight = new ColorClass();

	// Token: 0x040001FD RID: 509
	public ColorClass customPaintRHLight = new ColorClass();

	// Token: 0x040001FE RID: 510
	public ColorClass customMetallicPaintRHLight = new ColorClass();

	// Token: 0x040001FF RID: 511
	public ColorClass customPaintRoof = new ColorClass();

	// Token: 0x04000200 RID: 512
	public ColorClass customMetallicPaintRoof = new ColorClass();

	// Token: 0x04000201 RID: 513
	public ColorClass customPaintTrunk = new ColorClass();

	// Token: 0x04000202 RID: 514
	public ColorClass customMetallicPaintTrunk = new ColorClass();

	// Token: 0x04000203 RID: 515
	public ColorClass customDecalColor = new ColorClass();

	// Token: 0x04000204 RID: 516
	public int customDecal;

	// Token: 0x04000205 RID: 517
	public int economyState;

	// Token: 0x04000206 RID: 518
	public int routeLevel;

	// Token: 0x04000207 RID: 519
	public List<string> assignedInputStrings = new List<string>();

	// Token: 0x04000208 RID: 520
	public List<float> componentConditions = new List<float>();

	// Token: 0x04000209 RID: 521
	public List<int> primaryBuildingSaveList1 = new List<int>();

	// Token: 0x0400020A RID: 522
	public List<int> primaryBuildingSaveList2 = new List<int>();

	// Token: 0x0400020B RID: 523
	public List<int> primaryBuildingSaveList3 = new List<int>();

	// Token: 0x0400020C RID: 524
	public List<int> primaryBuildingSaveList4 = new List<int>();

	// Token: 0x0400020D RID: 525
	public List<int> primaryBuildingSaveList5 = new List<int>();

	// Token: 0x0400020E RID: 526
	public List<int> primaryBuildingSaveList6 = new List<int>();

	// Token: 0x0400020F RID: 527
	public List<int> hollowBuildingIndexSaveList1 = new List<int>();

	// Token: 0x04000210 RID: 528
	public List<int> hollowBuildingIndexSaveList2 = new List<int>();

	// Token: 0x04000211 RID: 529
	public List<int> hollowBuildingIndexSaveList3 = new List<int>();

	// Token: 0x04000212 RID: 530
	public List<int> hollowBuildingIndexSaveList4 = new List<int>();

	// Token: 0x04000213 RID: 531
	public List<int> hollowBuildingIndexSaveList5 = new List<int>();

	// Token: 0x04000214 RID: 532
	public List<int> hollowBuildingIndexSaveList6 = new List<int>();

	// Token: 0x04000215 RID: 533
	public List<int> oilBottleLevels = new List<int>();
}
