var express    = require('express');        // Utilizaremos express, aqui lo mandamos llamar

var app        = express();                 // definimos la app usando express
var bodyParser = require('body-parser'); //

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

//======================================================
var barquitos = express.Router();
var port = process.env.PORT || 8080;

// VARIABLES
var matriz = new Array();
var matrizIA = new Array();

var barcoPeque = [];
var barcoMediano = [];
var barcoGrande = [];

var indexBarco = 0;
var tablaDirecciones = [0, 1, -1];

var posInitX = 0;
var posInitY = 0;

var direccionBarco = [];

var listaDisparosIA = [];
// METODOS

var vidaBarcoPequeno = 2;
var vidaBarcoMediano = 4;
var vidaBarcoGrande = 6;

var putBarcos = true;

function parsearDireccio(grados){

    if(grados == 0){

        return [0, 1];
    } else if(grados == 90){

        return [-1, 0];
    } else if(grados == 180){

        return [0, -1];
    } else {

        return [1, 0];
    }
}

function ColocarBarcos(identificador, posInicial, direccion, tamanoBarco, barcosPlayer){

    if(barcosPlayer){
        arrayDireccion =  parsearDireccio(direccion);

        for (let i = 0; i < tamanoBarco; i++) {
        
            matriz[(posInicial[0]+(arrayDireccion[1]*i))][(posInicial[1]+(arrayDireccion[0]*i))] = identificador;
        }
    } else {

        for (let i = 0; i < tamanoBarco; i++) {
        
            matriz[(posInicial[0]+(direccion[1]*i))][(posInicial[1]+(direccion[0]*i))] = identificador;
        }
    }

    
}

function ColocarBarcosIA2(tipo, tipoBarco){

    var top = true;
    var down = true;
    var right = true;
    var left = true;
    var posInit;
    
    do{
        putBarcos = false;

        do{

            posInitX = Math.floor(Math.random() * 10);
            posInitY = Math.floor(Math.random() * 10);
        } while(!matriz[posInitX][posInitY] == "A");
        
        posInit = [posInitX, posInitY]

        for (let i = 1; i < tipoBarco; i++) {
            
            if(posInitX+(tipoBarco-1) < 9){
                if(!matriz[posInitX+(i*1)][posInitY+(i*0)] == "A"){
                    
                    down = false;  
                } 
            } else {
                down = false; 
            }

            if(posInitY+(tipoBarco-1) < 9){
                if(!matriz[posInitX+(i*0)][posInitY+(i*1)] == "A"){

                    left = false;
                }   
            } else {
                left = false;
            }

            if(posInitX - (tipoBarco-1) > 0){
                if(!matriz[posInitX+(i*(-1))][posInitY+(i*0)] == "A"){

                    top = false;   
                }
            } else {
                top = false;

            }

            if(posInitY - (tipoBarco-1) > 0){
                if(!matriz[posInitX+(i*0)][posInitY+(i*(-1))] == "A"){

                    right = false;  
                }  
            } else {
                right = false; 
            }
        }

        if(down){
            
            putBarcos = true;
            direccionBarco = [0, 1];
        } else if(left){
            
            putBarcos = true;
            direccionBarco = [1, 0];
        } else if(top){
            
            putBarcos = true;
            direccionBarco = [0, -1];
        } else if(right){
            
            putBarcos = true;
            direccionBarco = [-1, 0];
        } 

    } while(!putBarcos);

    
    console.log(posInit);
    console.log(direccionBarco);
    console.log(tipoBarco);

    ColocarBarcos(tipo, posInit, direccionBarco, tipoBarco, false);
}


function disparaPlayer(coordenadaPlayer){

    if(matriz[coordenadaPlayer[1]][coordenadaPlayer[0]] == "PIA"){

        vidaBarcoPequeno--;
        return "PIA";
    } else if(matriz[coordenadaPlayer[1]][coordenadaPlayer[0]] == "MIA"){

        vidaBarcoMediano--;
        return "MIA";
    } else if(matriz[coordenadaPlayer[1]][coordenadaPlayer[0]] == "GIA"){

        vidaBarcoGrande--;
        return "GIA";
    } else {
        
        return "A";
    }
}

function disparaIA(){

    var coordDispIAX;
    var coordDispIAY;
    var coordDispIA = [];

    coordDispIAX = Math.floor(Math.random() * 9);
    coordDispIAY = Math.floor(Math.random() * 9);

    if(listaDisparosIA != []){

        listaDisparosIA.forEach(array => {
        
            if(coordDispIAX == array[0] && coordDispIAY == array[1]){
    
                disparaIA();
            }
        });
    }

    coordDispIA[0] = coordDispIAX
    coordDispIA[1] = coordDispIAY;

    listaDisparosIA.push(coordDispIA);
    
    console.log(coordDispIA);

    return coordDispIA;
}

//LLAMADAS

barquitos.get('/cargamatriz', function(req, res) {

    for (let i = 0; i < 10; i++) {
        matriz[i] = [];
        for (let j = 0; j < 10; j++) {
            
            matriz[i][j] = "A";
        }
    }
    res.json();
});


barquitos.post('/colocarbarcos', function(req, res) {
    
    var parseBody = JSON.parse(req.body.json);
    if(req.body.json){
        
        ColocarBarcos(parseBody.tipo, parseBody.posicionInicial, parseBody.direccion, parseBody.tamano, true);
    }else{
        res.json({ "status": "ERROR"});
    }
});

barquitos.get('/colocarbarcosia', function(req, res) {

    ColocarBarcosIA2("GIA", 6);
    ColocarBarcosIA2("MIA", 4);
    ColocarBarcosIA2("PIA", 2);
    console.log(matriz);
});

barquitos.post('/dispararplayer', function(req, res) {
    if(req.body.json){
        
        var coordenadaPlayer = JSON.parse(req.body.json);

        if(disparaPlayer(coordenadaPlayer.coordenadas) == "PIA"){

            if(vidaBarcoPequeno <= 0){

                res.json({ "status": "PIA", "destruido": "SI"});
            } else {

                res.json({ "status": "PIA", "destruido": "NO"});
            }
        } else  if(disparaPlayer(coordenadaPlayer.coordenadas) == "MIA"){

            if(vidaBarcoMediano <= 0){

                res.json({ "status": "MIA", "destruido": "SI"});
            } else {

                res.json({ "status": "MIA", "destruido": "NO"});
            }
        } else if(disparaPlayer(coordenadaPlayer.coordenadas) == "GIA"){

            if(vidaBarcoGrande <= 0){

                res.json({ "status": "GIA", "destruido": "SI"});
            } else {

                res.json({ "status": "GIA", "destruido": "NO"});
            }
        }  else {

            res.json({ "status": "A", "destruido": "NO"});
        }
        
    }else{
        res.json({ "status": "ERROR"});
    }
});

barquitos.get('/dispararia', function(req, res) {
     
    var dispIA = disparaIA();

    console.log(dispIA);
    res.json({ "dispX": dispIA[0], "dispY": dispIA[1]});
});


// Le decimos a la aplicación que utilize las rutas que agregamos
app.use('/barquitos', barquitos);

// Iniciamos el servidor
app.listen(port);
console.log('Aplicación creada en el puerto: ' + port);