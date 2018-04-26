
//  var package = require('../package.json')
var remote = require("electron").remote

var development = process.defaultApp || /[\\/]electron-prebuilt[\\/]/.test(process.execPath) || /[\\/]electron[\\/]/.test(process.execPath);


function exeSquirrelCommand(args, cb) {
    var updateDotExe = path.resolve(path.dirname(process.execPath), '..', 'update.exe');
    var child = childProcess.spawn(updateDotExe, args, { detached: true });
    child.on('close', function () {
        cb();
    });
};

function install(cb) {
    var target = path.basename(process.execPath);
    exeSquirrelCommand(["--createShortcut", target], cb);
};


if (!development) {
    const autoUpdater = remote.autoUpdater

    autoUpdater.on('update-availabe', () => {
        console.log('update available')
    })
    autoUpdater.on('checking-for-update', () => {
        console.log('checking-for-update')
    })
    autoUpdater.on('update-not-available', () => {
        console.log('update-not-available')
    })

    autoUpdater.on('update-downloaded', (e) => {
        console.log(e)
        alert("Install?")
        autoUpdater.quitAndInstall()
    })

    autoUpdater.setFeedURL('https://s3-eu-west-1.amazonaws.com/dropworx/')

    autoUpdater.checkForUpdates()
    window.autoUpdater = autoUpdater
}
//alert(`Current version is: ${package.version}`);
//document.getElementById('version').innerHTML = `Current version is: ${package.version}`;
//document.write(`Current version is: ${package.version}`)

//document.write(`Development: ${development}`)


(function () {
    //document.getElementById('version').innerHTML = package.version;

})();
