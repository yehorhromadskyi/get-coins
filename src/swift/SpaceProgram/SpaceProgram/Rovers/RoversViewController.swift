//
//  RoversViewController.swift
//  SpaceProgram
//
//  Created by Yehor Hromadskyi on 13.03.19.
//  Copyright © 2019 Yehor Hromadskyi. All rights reserved.
//

import UIKit

class RoversViewController: UITableViewController {
    
    var rovers = [Rover]()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        var urlSession = URLSession(configuration: .default)
        var dataTask: URLSessionDataTask?
        
        var urlComponents = URLComponents(string: "https://api.nasa.gov/mars-photos/api/v1/rovers")
        urlComponents?.queryItems = [URLQueryItem(name: "api_key", value: AppSettings.apiSecret)]
        
        guard let url = urlComponents?.url else { return }
        
        dataTask = urlSession.dataTask(with: url) { data, response, error in
            defer { dataTask = nil }
            if let data = data, let response = response as? HTTPURLResponse, response.statusCode == 200 {
                do {
                    let decoder = JSONDecoder()
                    self.rovers = try decoder.decode(RoversResponse.self, from: data).rovers
                    print(self.rovers)
                    
                    DispatchQueue.main.async {
                        self.tableView.reloadData()
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
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let destinationController = segue.destination as! PhotosViewController
        destinationController.rover = rovers[tableView.indexPathForSelectedRow?.row ?? 0]
    }
}

extension RoversViewController {
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return rovers.count
    }
    
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "RoverCell", for: indexPath)
        
        let rover = rovers[indexPath.row]
        cell.textLabel?.text = rover.name
        cell.detailTextLabel?.text = rover.status
        return cell;
    }
}
