const http = require('http')

module.exports = json => new Promise((resolve, reject) => {

  const data = JSON.stringify(json)

  const reqCfg = {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
      'Content-Length': Buffer.byteLength(data),
    },
  }
  const req = http.request('http://mock-proxy:1080/mockserver/expectation', reqCfg, resp => {

    let streamData = ''
    // A chunk of data has been recieved.
    resp.on('data', (chunk) => {
      streamData += chunk
    })

    // The whole response has been received. Print out the result.
    resp.on('end', () => {
      resolve(streamData)
    })

  }).on('error', reject)

  req.write(data)
  req.end()
})