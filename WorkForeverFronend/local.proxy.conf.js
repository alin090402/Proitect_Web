const ProxyConfig = [
{
    context: [
        "/api"
    ],
    target: "https://localhost:7134",
    secure: false
}];

module.exports = ProxyConfig;
