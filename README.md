# EntityFrameWorkWithAPIExample

 Se till att byta ut adressen till den lokala databasen innan uppstart. Både i DataContextFactory.cs och Program.cs


## API Endpoints

### Scalar API Reference  
📌 [Scalar UI](http://localhost:5062/scalar/v1) – Interaktiv dokumentation för API:et.  

### Games API  
🎮 Hämta speldata via dessa endpoints:  

- **Alla spel:** [`/api/v1/games`](http://localhost:5062/api/v1/games)  
- **Sök spel via titel:** [`/api/v1/games?title=a`](http://localhost:5062/api/v1/games?title=a)  
- **Hämta spel via ID:** [`/api/v1/games/3`](http://localhost:5062/api/v1/games/3)  