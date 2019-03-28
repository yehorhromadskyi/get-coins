//
//  RoverManifestResponse.swift
//  SpaceProgram
//
//  Created by Yehor Hromadskyi on 28.03.19.
//  Copyright © 2019 Yehor Hromadskyi. All rights reserved.
//

import Foundation

public struct RoverManifestResponse : Decodable {
    public let photo_manifest: RoverManifest
}
