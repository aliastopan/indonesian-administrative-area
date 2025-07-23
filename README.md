# Wilayah Administratif Indonesia

Repositori ini menyediakan data JSON untuk semua wilayah administratif di Indonesia.
- Folder `data/json` berisi data mentah yang bersumber dari wilayah.id.
- Folder `data/index` berisi file JSON terstruktur dan telah diperkaya.

## Kode Wilayah

`[A1][A2].[B1][B2].[C1][C2].[D1][D2][D3][D4]`

 | Kode | Keterangan |
 | :--- | :--- |
 | **[A1][A2]** | Kode Provinsi |
 | **[B1][B2]** | Kode Kabupaten/Kota |
 | | `B1` = 0 s/d 6 adalah **Kabupaten** |
 | | `B2` = 7 s/d 9 adalah **Kota** |
 | **[C1][C2]** | Kode Kecamatan |
 | **[D1][D2][D3][D4]** | Kode Kelurahan/Desa |
 | | `D1` = 1 adalah **Kelurahan** |
 | | `D2` = 2 adalah **Desa** |

### Contoh:
`35.78.24.1001`

- `35` = Kode Provinsi
- `78` = Kode Kabupaten/Kota
- `24` = Kode Kecamatan
- `1001` Kode Kelurahan/Desa

`35.78.24.1001` = Kel. Kutisari, Kec. Tenggilis Mejoyo, Kota Surabaya, Jawa Timur


## Berkas — `data/json`

### `provinces.json`
```
[
  ...
  {
    "Code": "35",
    "Name": "Jawa Timur"
  },
  {
    "Code": "36",
    "Name": "Banten"
  },
  ...
]
```

### `regencies.json`
```
[
  ...
  {
    "Code": "35.78",
    "ProvinceCode": "35",
    "Name": "Kota Surabaya"
  },
  {
    "Code": "35.79",
    "ProvinceCode": "35",
    "Name": "Kota Batu"
  },
  ...
]
```

### `districts.json`
```
[
  ...
  {
    "Code": "35.78.24",
    "RegencyCode": "35.78",
    "Name": "Tenggilis Mejoyo"
  },
  {
    "Code": "35.78.25",
    "RegencyCode": "35.78",
    "Name": "Gunung Anyar"
  },
  ...
]
```

### `villages.json`
```
[
  ...
  {
    "Code": "35.78.24.1001",
    "DistrictCode": "35.78.24",
    "Name": "Kutisari"
  },
  {
    "Code": "35.78.24.1002",
    "DistrictCode": "35.78.24",
    "Name": "Kendangsari"
  },
  ...
]
```

## Berkas — `data/index`

### `province.index.json`
```
[
  ...
  {
    "id": "35",
    "type": "Provinsi",
    "name": "Jawa Timur",
    "full_path": "Jawa Timur"
  },
  {
    "id": "36",
    "type": "Provinsi",
    "name": "Banten",
    "full_path": "Banten"
  },
  ...
]
```

### `regencies.index.json`
```
[
  ...
  {
    "id": "35.78",
    "type": "Kota",
    "name": "Surabaya",
    "context": {
      "province": "Jawa Timur"
    },
    "full_path": "Kota Surabaya, Jawa Timur"
  },
  {
    "id": "35.79",
    "type": "Kota",
    "name": "Batu",
    "context": {
      "province": "Jawa Timur"
    },
    "full_path": "Kota Batu, Jawa Timur"
  },
  ...
]
```

### `district.index.json`
```
[
  ...
  {
    "id": "35.78.24",
    "type": "Kecamatan",
    "name": "Tenggilis Mejoyo",
    "context": {
      "regency": "Kota Surabaya",
      "province": "Jawa Timur"
    },
    "full_path": "Kec. Tenggilis Mejoyo, Kota Surabaya, Jawa Timur"
  },
  {
    "id": "35.78.25",
    "type": "Kecamatan",
    "name": "Gunung Anyar",
    "context": {
      "regency": "Kota Surabaya",
      "province": "Jawa Timur"
    },
    "full_path": "Kec. Gunung Anyar, Kota Surabaya, Jawa Timur"
  },
  ...
]
```

### `villages.index.json`
```
[
  ...
  {
    "id": "35.78.24.1001",
    "type": "Kelurahan",
    "name": "Kutisari",
    "context": {
      "district": "Tenggilis Mejoyo",
      "regency": "Kota Surabaya",
      "province": "Jawa Timur"
    },
    "full_path": "Kel. Kutisari, Kec. Tenggilis Mejoyo, Kota Surabaya, Jawa Timur"
  },
  {
    "id": "35.78.24.1002",
    "type": "Kelurahan",
    "name": "Kendangsari",
    "context": {
      "district": "Tenggilis Mejoyo",
      "regency": "Kota Surabaya",
      "province": "Jawa Timur"
    },
  ...
]
```

## Credit

- Sumber: [cahyadsn/wilayah.id](https://github.com/cahyadsn/wilayah#change-log).
- Referensi tambahan: [m.nomor.net](https://m.nomor.net/_kodepos.php?_i=kode-wilayah)

