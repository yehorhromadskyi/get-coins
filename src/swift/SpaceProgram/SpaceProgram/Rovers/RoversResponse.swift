//
//  RoversResponse.swift
//  SpaceProgram
//
//  Created by Yehor Hromadskyi on 19.03.19.
//  Copyright © 2019 Yehor Hromadskyi. All rights reserved.
//

import Foundation

public struct RoversResponse : Decodable {
    public let rovers: [Rover]
}
