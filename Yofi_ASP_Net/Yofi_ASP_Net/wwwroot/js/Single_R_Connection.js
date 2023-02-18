var signalRConnection = new signalR.HubConnectionBuilder().withUrl("/MineSocket").build();
const plus_counter = document.querySelector("#plus_counter");

const signalRInvoker = async (event, data) => {
    await signalRConnection.invoke(event, JSON.stringify(data))
}




(async () => {
    await signalRConnection.start()
    
    document.querySelector("#plus_counter").onclick = () => {
        signalRInvoker("Number_Caller", {
            msg:"plus"
        })
    }
    document.querySelector("#min_counter").onclick = () => {
        signalRInvoker("Number_Caller", {
            msg: "min"
        })
    }
    signalRConnection.on("Number_Caller", (msg) => {
        document.querySelector("#value").textContent = JSON.parse(msg).msg
    })
})()


