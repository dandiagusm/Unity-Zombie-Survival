# Morty and The Cronenberg
## Deskripsi
Morty and The Cronenberg adalah sebuah game 2D bergenre wave survival. 
Morty terbangun tengah malam di sebuah kabin di tengah hutan. 
Morty tidak ingat apa-apa mengenai apa yang telah terjadi. 
Saat Morty berusaha mengingat, Morty mendengar suara berisik langkah kaki orang dari luar kabin. 
Morty pun mendekati jendela, terlihat banyak orang yang ingin masuk ke kabin kamu. 
Akan tetapi, mengapa mereka terlihat tidak seperti orang?? 
Bantulah Morty tanpa bantuan Rick untuk selamat dari kumpulan zombie yang mendekat.

## Cara kerja
1. Scene
    Game terdiri dari buah scene, yaitu scane GUI Menu dan Main Game. Untuk membuat 2 scene ini dapat dilakukan dengan penambahan scene melalui menu. Lalu kita dapat mengganti scene dengan menggunakan index scene yang didaftarkan.
2. Camera
    Camera yang dibuat dapat mengikuti pergerakan pemain. Untuk melakukan hal ini dapat dilakukan dengan camera mengikuti posisi dari objek player.
3. Animation
    Terdapat beberapa animasi bagi player dan enemy. Animasi ini dapat dibuat melalui Animator yang telah tersidia di Unity.
4. Movement
    Untuk melakukan movement pada map 2D, kita dapat mengubah bagian Transform X dan Y pada GameObject
5. Enemy dan Wave Spawner
    Terdapat banyak objek enemy ketika permainan dimulai, akan tetapi pembuatan enemy ini hanya dilakukan dengan membuat objek enemy sekali lalu dibuat menjadi prefabs yang kemudian akan dirandomisasi spawn oleh wave spawner
6. Health
    status health berubah apabila terjadi collision antara objek tangan zombie dengan player.
7. Score
    Ketika health zombie <= 0, objek zombie akan dihancurkan dan player mendapatkan score. Health zombie berkurang ketika terjadi collision dengan peluru
8. Map
    Map yang dibuat diterapkan menggunakan Tilemap 2D.

## Library
1. UnityWebRequet : Digunakan untuk melakukan get dan fetch dari API
2. JSONUtility : Digunakan untuk melakukan encodin terhdapat objek json yang diterima