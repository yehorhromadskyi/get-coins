//
//  RoversViewController.swift
//  SpaceProgram
//
//  Created by Yehor Hromadskyi on 13.03.19.
//  Copyright © 2019 Yehor Hromadskyi. All rights reserved.
//

import UIKit

class RoversViewController: UITableViewController {
    
    var rovers = [Rover(name: "Opportunity", active: true),
                  Rover(name: "Curiosity", active: true),
                  Rover(name: "Fake", active: false)]
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
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
        cell.detailTextLabel?.text = rover.active ? "Active" : "Not active"
        return cell;
    }
}
