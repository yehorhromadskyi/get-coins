//
//  RoverManifest.swift
//  SpaceProgram
//
//  Created by Yehor Hromadskyi on 28.03.19.
//  Copyright © 2019 Yehor Hromadskyi. All rights reserved.
//

import Foundation

public struct RoverManifest : Decodable {
    public let launch_date: String
    public let landing_date: String
}
