var express    = require('express');        // Utilizaremos express, aqui lo mandamos llamar

var app        = express();                 // definimos la app usando express
var bodyParser = require('body-parser'); //

var UsersModel  = require('./models/userModel');

//======================================================
var baquitos = express.Router();


// VARIABLES
var matriz = new Array(2);

var barcoPeque = [];
var barcoMediano = [];
var barcoGrande = [];

var indexBarco = 0;
var tablaDirecciones = [0, 1, -1];
var barcoColocar = [] 

var posInitX = 0;
var posInitY = 0;

var direccionBarco = []

var listaDisparosIA = []
// METODOS

var vidaBarcoPequeno = 2;
var vidaBarcoMediano = 4;
var vidaBarcoGrande = 6;

function parsearDireccio(grados){

    if(grados == 0){

        return [0, -1];
    } else if(grados == 90){

        return [1, 0];
    } else if(grados == 180){

        return [0, 1];
    } else {

        return [-1, 0];
    }
}

function ColocarBarcos(identificador, posInicial, direccion, tamanoBarco){

    arrayDireccion =  parsearDireccio(direccion);
    for (let i = 0; i < tamanoBarco; i++) {

        matriz[posInicial[0+(arrayDireccion[0]*i)]][posInicial[1]+(arrayDireccion[1]*i)] = identificador;
    }
}


function ComprobarBarcos(x, y, tipoBarco){
    
    var direccionX = x;
    var direccionY = y;
    direccionBarco = [x, y]

    barcoColocar.push(matrix[posInitX][posInitY]);

    for (let i = 1; i <= tipoBarco; i++) {

        if(posInitX+(i*tablaDirecciones[direccionX]) < 10 && posInitY+(i*tablaDirecciones[direccionY]) < 10 ){

            if(matrix[posInitX+(i*tablaDirecciones[direccionX])][posInitY+(i*tablaDirecciones[direccionY])] != "A"){

                if(direccionX == 1 && direccionY == 0){
                    
                    ComprobarBarcos(0, 1, tipoBarco);
                } else if(direccionX == 0 && direccionY == 1){
                    
                    ComprobarBarcos(2, 0, tipoBarco);
                } else if(direccionX == 2 && direccionY == 0){
                    
                    ComprobarBarcos(0, 2, tipoBarco);
                } else{
                    
                    return false;
                } 
            }
        } else {

            return false;
        }
    } 

    return true;
}

function ColocarBarcosIA(tipoBarco){

    do{

        posInitX = Math.floor(Math.random() * 10);
        posInitY = Math.floor(Math.random() * 10);
    } while(!matrix[posInitX][posInitY] == "A");
 
    switch (indexBarco) {
        case 0:
            
            if(ComprobarBarcos(1, 0, tipoBarco)){

                indexBarco = 1;
                barcoPeque = [posInitX, posInitY];
                ColocarBarcos("PIA", barcoPeque, direccionBarco, tipoBarco)
                barcoColocar = [];
            } else {

                ColocarBarcosIA(4);
            }            
            break;
        case 1:

            if(ComprobarBarcos(1, 0, tipoBarco)){

                indexBarco = 2;
                barcoMediano = [posInitX, posInitY];
                ColocarBarcos("MIA", barcoMediano, direccionBarco, tipoBarco)
                barcoColocar = [];
            } else {

                ColocarBarcosIA(6);
            }  
            break;
        case 2:
    
            if(ComprobarBarcos(1, 0, tipoBarco)){

                indexBarco = 2;
                barcoGrande = [posInitX, posInitY];
                ColocarBarcos("GIA", barcoGrande, direccionBarco, tipoBarco)
                barcoColocar = [];
            } else {

                ColocarBarcosIA(6);
            }
            break;
        default:
            break;
    }
}


function disparaPlayer(coordenadaPlayer){

    if(matriz[coordenadaPlayer[0]][coordenadaPlayer[1]] == "PIA"){

        vidaBarcoPequeno--;
        return true;
    } else if(matriz[coordenadaPlayer[0]][coordenadaPlayer[1]] == "MIA"){

        vidaBarcoMediano--;
        return true;
    } else if(matriz[coordenadaPlayer[0]][coordenadaPlayer[1]] == "GIA"){

        vidaBarcoGrande--;
        return true;
    } else {
        
        return false;
    }
}

function disparaIA(){

    var coordDispIAX;
    var coordDispIAY;

    coordDispIAX = Math.floor(Math.random() * 10);
    coordDispIAY = Math.floor(Math.random() * 10);

    array.forEach(listaDisparosIA => {
        
        if(coordDispIAX == array[0] && coordDispIAY == array[1]){

            disparaIA()
        }
    });

    listaDisparosIA.push([coordDispIAX][coordDispIAY]);

    if(listaDisparosIA.lastIndexOf() == "P"){

    } else if(listaDisparosIA.lastIndexOf() == "M"){

    } else if(listaDisparosIA.lastIndexOf() == "G"){

    } else {

    }
}

//LLAMADAS

baquitos.get('/cargamatriz', function(req, res) {

    for (let i = 0; i < 10; i++) {
        for (let j = 0; j < 10; j++) {
            
            matriz[i][j] = "A";
        }
    }

    res.json({ "word": palabraActualCifrada});
});


baquitos.get('/colocarbarcos', function(req, res) {
    if(req.body.barcos){
        
        // desfragmetar json barcos

        ColocarBarcos(identificador, posInicial, direccion, tamanoBarco);
        ColocarBarcosIA(2);
    }else{
        res.json({ "status": "ERROR"});
    }
});

baquitos.post('/dispararplayer', function(req, res) {
    if(req.body.coordenadaPlayer){
        
        if(disparaPlayer(coordenadaPlayer)){

            if(vidaBarcoPequeno <= 0){

                res.json({ "status": "ERROR", "status": "ERROR"});
            } else if(vidaBarcoMediano <= 0){

                res.json({ "status": "ERROR", "status": "ERROR"});
            } else if(vidaBarcoGrande <= 0){

                res.json({ "status": "ERROR", "status": "ERROR"});
            } else {

                res.json({ "status": "ERROR", "status": "ERROR"});
            }

        } else {

            res.json({ "status": "ERROR"});
        }
    }else{
        res.json({ "status": "ERROR"});
    }
});

baquitos.post('/dispararia', function(req, res) {
    if(req.body.coordenadaPlayer){
        
        disparaIA()
    }else{
        res.json({ "status": "ERROR"});
    }
});


// Le decimos a la aplicación que utilize las rutas que agregamos
app.use('/baquitos', baquitos);

// Iniciamos el servidor
app.listen(port);
console.log('Aplicación creada en el puerto: ' + port);