// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-FileCopyrightText: 2025 Solstice <solsticeofthewinter@gmail.com>
// SPDX-FileCopyrightText: 2025 SolsticeOfTheWinter <solsticeofthewinter@gmail.com>
// SPDX-FileCopyrightText: 2025 cohanna <conornhanna@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

namespace Content.Goobstation.Server.Implants.Components;

[RegisterComponent]
public sealed partial class WeakSpaceProofImplantComponent : Component
{
    /// <summary>
    /// Was the entity immune to spacing before being implanted?
    /// </summary>
    [DataField] public bool WasntSpaceProof = false;

    /// <summary>
    /// Was the entity low temp immune before being implanted?
    /// </summary>
    [DataField] public bool WasntLowTempProof = false;

}
