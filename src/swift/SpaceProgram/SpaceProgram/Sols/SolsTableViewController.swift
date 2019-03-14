//
//  SolsTableViewController.swift
//  SpaceProgram
//
//  Created by Yehor Hromadskyi on 14.03.19.
//  Copyright © 2019 Yehor Hromadskyi. All rights reserved.
//

import UIKit

class SolsTableViewController: UITableViewController {

    var sols = [Int(1000), Int(999), Int(998)]
    
    override func viewDidLoad() {
        super.viewDidLoad()
    }
}

extension SolsTableViewController {
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return sols.count
    }
    
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "SolCell", for: indexPath)
        
        cell.textLabel?.text = String(sols[indexPath.row])
        return cell
    }
}
