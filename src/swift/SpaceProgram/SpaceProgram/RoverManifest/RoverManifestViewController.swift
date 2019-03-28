//
//  RoverManifestViewController.swift
//  SpaceProgram
//
//  Created by Yehor Hromadskyi on 27.03.19.
//  Copyright © 2019 Yehor Hromadskyi. All rights reserved.
//

import UIKit

class RoverManifestViewController: UITableViewController {
    
    @IBOutlet weak var launchDateLabel: UILabel!
    
    var rover: Rover?
    
    override func viewDidLoad() {
        super.viewDidLoad()

        title = rover?.name
        
        var urlSession = URLSession(configuration: .default)
        var dataTask: URLSessionDataTask?
        
        var stringUrl = "https://api.nasa.gov/mars-photos/api/v1/manifests/" + title!
        var urlComponents = URLComponents(string: stringUrl)
        urlComponents?.queryItems = [URLQueryItem(name: "api_key", value: AppSettings.apiSecret)]
        
        guard let url = urlComponents?.url else { return }
        
        dataTask = urlSession.dataTask(with: url) { data, response, error in
            defer { dataTask = nil }
            if let data = data, let response = response as? HTTPURLResponse, response.statusCode == 200 {
                do {
                    let decoder = JSONDecoder()
                    let date = try decoder.decode(RoverManifestResponse.self, from: data).photo_manifest.launch_date
                    
                    DispatchQueue.main.async {
                        self.launchDateLabel.text = date
                    }
                } catch let error {
                    print(error)
                }
            }
            else if let error = error {
                print(error)
            }
        }
        
        dataTask?.resume()
    }
    

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
    }
    */

}
